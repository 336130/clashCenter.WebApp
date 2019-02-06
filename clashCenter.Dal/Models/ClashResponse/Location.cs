using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clashCenter.Dal.Models.ClashResponse
{
    public class Location
    {
        public int id { get; set; }
        public string name { get; set; }
        public bool isCountry { get; set; }
        public string countryCode { get; set; }
    }
}
