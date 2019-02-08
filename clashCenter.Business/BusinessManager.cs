using clashCenter.Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using clashCenter.Dal.Models.ClashResponse;
using Location = clashCenter.Dal.Location;
using clashCenter.Dal.Models;

namespace clashCenter.Business
{
    public class BusinessManager
    {
        public BusinessManager()
        {

        }

        public ClanSearchResults SearchForClan(string name,string warFrequency, int minMembers,int maxMembers, int minClanPoints, int minClanLevel, int location)
        {
            List<Parameter> par = new List<Parameter>();
            par.Add(new Parameter { key = "name=", value = name });
            par.Add(new Parameter { key = "warFrequency=", value = warFrequency });
            par.Add(new Parameter { key = "minMembers=", value = minMembers.ToString() });
            par.Add(new Parameter { key = "maxMembers=", value = maxMembers.ToString() });
            par.Add(new Parameter { key = "minClanPoints=", value = minClanPoints.ToString() });
            par.Add(new Parameter { key = "minClanLevel=", value = minClanLevel.ToString() });
            par.Add(new Parameter { key = "location=", value = location.ToString() });

            par.RemoveAll(p => string.IsNullOrWhiteSpace(p.value) || p.value == "0");

            return new ClashAccessManager().SearchForClans(par); 
        }

        public List<Location> GetLocations()
        {
            return new DatabaseAccessManager().GetLocations();
        }
    }
}
