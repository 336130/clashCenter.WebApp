using clashCenter.Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using clashCenter.Dal.Models.ClashResponse;

namespace clashCenter.Business
{
    public class BusinessManager
    {
        public BusinessManager()
        {

        }

        public ClanSearchResults SearchForClan(string term)
        {
            ClanSearchResults retVal = new ClanSearchResults();
            var accessManager = new ClashAccessManager();
            retVal = accessManager.SearchForClans(term); 
            return retVal;
        }
    }
}
