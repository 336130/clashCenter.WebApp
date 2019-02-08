using clashCenter.Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace clashCenter.Models.ResponseObjects
{
    public class LocationViewModel
    {
        public LocationViewModel(Location loc)
        {
            ID = loc.ID;
            LocationID = loc.LocationID;
            Name = loc.Name;
            IsCountry = loc.IsCountry;
            CountryCode = loc.CountryCode;
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public bool IsCountry { get; set; }
        public string CountryCode { get; set; }
        public int LocationID { get; set; }
    }
}