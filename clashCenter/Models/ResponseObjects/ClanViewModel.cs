using clashCenter.Dal.Models.ClashResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clashCenter.Models.ResponseObjects
{
    public class ClanViewModel
    {
        public ClanViewModel(Clan clan)
        {
            Tag = clan.Tag;
            Name = clan.Name;
            Location = clan.Location != null ? new LocationViewModel(clan.Location) : null;
            BadgeURLs = clan.BadgeUrls != null ? new BadgeViewModel(clan.BadgeUrls) : null;
            ClanLevel = clan.ClanLevel;
            ClanPoints = clan.ClanPoints;
            ClanVersusPoints = clan.ClanVersusPoints;
            Members = clan.Members;
            Type = clan.Type;
            RequiredTrophies = clan.RequiredTrophies;
            WarFrequency = clan.WarFrequency;
            WarWinStreak = clan.WarWinStreak;
            WarWins = clan.WarWins;
            WarTies = clan.WarTies;
            WarLosses = clan.WarLosses;
            IsWarLogPublic = clan.IsWarLogPublic;
            Description = clan.Description;
            IsFavorite = clan.IsFavorite;
            IsInterest = clan.IsInterest;

            MemberList = new List<ClanMemberViewModel>();

            foreach (var member in clan.MemberList)
            {
                MemberList.Add(new ClanMemberViewModel(member));
            }
        }

        public string Tag { get; set; }
        public string Name { get; set; }
        public LocationViewModel Location { get; set; }
        public BadgeViewModel BadgeURLs { get; set; }
        public int ClanLevel { get; set; }
        public int ClanPoints { get; set; }
        public int ClanVersusPoints { get; set; }
        public int Members { get; set; }
        public string Type { get; set; }
        public int RequiredTrophies { get; set; }
        public string WarFrequency { get; set; }
        public int WarWinStreak { get; set; }
        public int WarWins { get; set; }
        public int WarTies { get; set; }
        public int WarLosses { get; set; }
        public bool IsWarLogPublic { get; set; }
        public string Description { get; set; }
        public List<ClanMemberViewModel> MemberList { get; set; }
        public bool IsInterest { get; set; }
        public bool IsFavorite { get; set; }
    }
}
