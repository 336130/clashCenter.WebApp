//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace clashCenter.Dal
{
    using System;
    using System.Collections.Generic;
    
    public partial class ClanHistoryMember
    {
        public int ClanHistoryMemberID { get; set; }
        public Nullable<int> ClanHistoryID { get; set; }
        public string MemberTag { get; set; }
        public string MemberName { get; set; }
        public int ExpLevel { get; set; }
        public int Trophies { get; set; }
        public int VersusTrophies { get; set; }
        public string ClanRole { get; set; }
        public int ClanRank { get; set; }
        public int PreviousClanRank { get; set; }
        public int Donations { get; set; }
        public int DonationsRecieved { get; set; }
    
        public virtual ClanHistory ClanHistory { get; set; }
    }
}