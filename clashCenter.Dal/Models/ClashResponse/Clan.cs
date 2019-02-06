using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clashCenter.Dal.Models.ClashResponse
{
    public class Clan
    {
        public string Tag { get; set; }
        public string Name { get; set; }
        public Location Location { get; set; }
        public Badge BadgeUrls { get; set; }
        public int ClanLevel { get; set; }
        public int ClanPoints { get; set; }
        public int ClanVersusPoints { get; set; }
        public int Members { get; set; }
        public string Type { get; set;}
        public int RequiredTrophies { get; set; }
        public string WarFrequency { get; set; }
        public int WarWinStreak { get; set; }
        public int WarWins { get; set; }
        public int WarTies { get; set; }
        public int WarLosses { get; set; }
        public bool IsWarLogPublic { get; set; }
        public string Description { get; set; }
        public List<ClanMembers> MemberList { get; set; }
    }
}
