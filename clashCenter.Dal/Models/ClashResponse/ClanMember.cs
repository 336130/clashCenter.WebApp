﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clashCenter.Dal.Models.ClashResponse
{
    public class ClanMember
    {
        public string Tag { get; set; }
        public string Name { get; set; }
        public int ExpLevel { get; set; }
        public int Trophies { get; set; }
        public int VersusTrophies { get; set; }
        public string Role { get; set; }
        public int ClanRank { get; set; }
        public int PreviousClanRank { get; set; }
        public int Donations { get; set; }
        public int DonationsReceived { get; set; }
    }
}
