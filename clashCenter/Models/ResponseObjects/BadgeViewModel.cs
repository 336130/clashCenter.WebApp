using clashCenter.Dal.Models.ClashResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clashCenter.Models.ResponseObjects
{
    public class BadgeViewModel
    {
        public BadgeViewModel(Badge badge)
        {
            Small = badge.Small;
            Medium = badge.Medium;
            Large = badge.Large;
        }
        public string Small { get; set; }
        public string Medium { get; set; }
        public string Large { get; set; }
    }
}
