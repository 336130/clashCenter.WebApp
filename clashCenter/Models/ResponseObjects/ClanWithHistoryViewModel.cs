using clashCenter.Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clashCenter.Models.ResponseObjects
{
    public class ClanWithHistoryViewModel
    {
        public ClanWithHistoryViewModel(ClanWithHistory clanWithHistory)
        {
            Latest = new ClanViewModel(clanWithHistory.Latest);
            History = new List<ClanViewModel>();
            foreach (var clanHistory in clanWithHistory.History)
            {
                History.Add(new ClanViewModel(clanHistory));
            }
        }
        public ClanViewModel Latest { get; set; }
        public List<ClanViewModel> History { get; set; }
    }
}
