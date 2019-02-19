using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clashCenter.Dal.Models
{
    public class ClanWithHistory
    {
        public ClashResponse.Clan Latest { get; set; }
        public List<ClashResponse.Clan> History { get; set; }
    }
}
