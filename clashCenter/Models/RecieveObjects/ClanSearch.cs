using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace clashCenter.Web.Models.RecieveObjects
{
    public class ClanSearch
    {
        public string name { get; set; }
        public string warFrequency { get; set; }
        public int minMembers { get; set; }
        public int maxMembers { get; set; }
        public int minClanPoints { get; set; }
        public int minClanLevel { get; set; }
    }
}