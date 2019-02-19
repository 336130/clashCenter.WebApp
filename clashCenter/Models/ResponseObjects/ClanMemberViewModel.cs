using clashCenter.Dal.Models.ClashResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clashCenter.Models.ResponseObjects
{
    public class ClanMemberViewModel
    {
        public ClanMemberViewModel(ClanMember clanMember)
        {
            Tag = clanMember.Tag;
            Name = clanMember.Name;
            ExpLevel = clanMember.ExpLevel;
            Trophies = clanMember.Trophies;
            VersusTrophies = clanMember.VersusTrophies;
            Role = clanMember.Role;
            ClanRank = clanMember.ClanRank;
            PreviousClanRank = clanMember.PreviousClanRank;
            Donations = clanMember.Donations;
            DonationsRecieved = clanMember.DonationsReceived;
        }

        public string Tag { get; set; }
        public string Name { get; set; }
        public int ExpLevel { get; set; }
        public int Trophies { get; set; }
        public int VersusTrophies { get; set; }
        public string Role { get; set; }
        public int ClanRank { get; set; }
        public int PreviousClanRank { get; set; }
        public int Donations { get; set; }
        public int DonationsRecieved { get; set; }
    }
}
