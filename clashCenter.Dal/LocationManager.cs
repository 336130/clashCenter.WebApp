using clashCenter.Dal.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace clashCenter.Dal
{
    public class LocationManager
    {
        public List<Location> GetAllLocations()
        {
            using (var context = new ClashCenterEntities())
            {
                return context.Locations.ToList();
            }
        }
    }
}
