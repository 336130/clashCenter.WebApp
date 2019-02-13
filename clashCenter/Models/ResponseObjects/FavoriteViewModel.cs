using clashCenter.Dal.Models.ClashResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace clashCenter.Models.ResponseObjects
{
    public class FavoriteViewModel
    {
        public FavoriteViewModel()
        {
            Location = new Location();
            BadgeURLs = new Badge();
            IsFavorite = true;
        }

        public FavoriteViewModel(Clan clan,bool interest) : base()
        {
            Tag = clan.Tag;
            Name = clan.Name;
            Location = clan.Location;
            ClanLevel = clan.ClanLevel;
            ClanPoints = clan.ClanPoints;
            ClanVersusPoints = clan.ClanVersusPoints;
            Members = clan.Members;
            BadgeURLs = clan.BadgeUrls;
            IsInterest = interest;
            IsFavorite = true;
        }

        public string Tag { get; set; }
        public string Name { get; set; }
        public Location Location { get; set; }
        public int  ClanLevel { get; set; }
        public int ClanPoints { get; set; }
        public int ClanVersusPoints { get; set; }
        public int Members { get; set; }
        public Badge BadgeURLs { get; set; }
        public bool IsFavorite { get; set; }
        public bool IsInterest { get; set; }
    }
}