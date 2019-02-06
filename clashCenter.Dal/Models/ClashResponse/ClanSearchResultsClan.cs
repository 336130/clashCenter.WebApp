using clashCenter.Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clashCenter.Dal.Models.ClashResponse
{
    public class ClanSearchResultsClan
    {
      public string Tag { get; set; }
      public string Name { get; set; }
      public Location Location { get; set; }
      public int ClanLevel { get; set; }
      public int ClanPoints { get; set; }
      public int ClanVersusPoints { get; set; }
      public int Members { get; set; }
        public Badge BadgeURLs { get; set; }
    }
}
