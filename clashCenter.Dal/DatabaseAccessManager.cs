using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clashCenter.Dal
{
    public class DatabaseAccessManager
    {
        private List<Location> _locations;

        public DatabaseAccessManager()
        {
            using (var dbContxt = new ClashCenterEntities())
            {
                _locations = dbContxt.Locations.ToList();
            }
        }

        #region Create
        public void SaveClanInfo(Models.ClashResponse.Clan clan)
        {
            using (var dbContext = new ClashCenterEntities())
            {
                //try fetch clan from db, add new clan record is not
                Clan existingClan = dbContext.Clans.FirstOrDefault(c => c.ClanTag == clan.Tag);
                if (existingClan == null)
                {
                    existingClan = dbContext.Clans.Add(new Clan
                    {
                        ClanTag = clan.Tag,
                        FirstPolled = DateTime.Now
                    });
                    dbContext.SaveChanges();//save to get clanID
                }

                //location data is abit screwy because of location import
                var location = _locations.FirstOrDefault(l => l.Name == clan.Location?.name);

                var clanHistory = dbContext.ClanHistories.Add(new ClanHistory
                {
                    ClanID = existingClan.ClanID,
                    ClanName = clan.Name,
                    LocationID = location?.ID,
                    ClanLevel = clan.ClanLevel,
                    ClanPoints = clan.ClanPoints,
                    ClanVersusPoints = clan.ClanVersusPoints,
                    MemberCount = clan.Members,
                    ClanType = clan.Type,
                    RequiredTrophies = clan.RequiredTrophies,
                    WarFrequency = clan.WarFrequency,
                    WarWinStreak = clan.WarWinStreak,
                    WarWins = clan.WarWins,
                    WarTies = clan.WarTies,
                    WarLosses = clan.WarLosses,
                    IsWarLogPublic = clan.IsWarLogPublic,
                    Description = clan.Description,
                    DatePolled = DateTime.Now
                });

                //save to get clanhistoryid
                dbContext.SaveChanges();

                foreach (var member in clan.MemberList)
                {
                    dbContext.ClanHistoryMembers.Add(new ClanHistoryMember
                    {
                        ClanHistoryID = clanHistory.ClanHistoryID,
                        MemberTag = member.Tag,
                        MemberName = member.Name,
                        ExpLevel = member.ExpLevel,
                        Trophies = member.Trophies,
                        VersusTrophies = member.VersusTrophies,
                        ClanRole = member.Role,
                        ClanRank = member.ClanRank,
                        PreviousClanRank = member.PreviousClanRank,
                        Donations = member.Donations,
                        DonationsRecieved = member.DonationsRecieved
                    });

                    //save each member
                    dbContext.SaveChanges();
                }
            }
        }
        #endregion

        #region Read
        public List<Location> GetLocations()
        {
            using (var dbContext = new ClashCenterEntities())
            {
                return dbContext.Locations.ToList();
            }
        }
        #endregion
    }
}
