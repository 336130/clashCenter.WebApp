using clashCenter.DAL.Models;
using clashCenter.Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using clashCenter.Dal.Models;

namespace clashCenter.Business
{
    public class BusinessManager
    {
        public BusinessManager()
        {

        }

        public ClanList SearchForClan(string term)
        {
            ClanList retVal = new ClanList();
            var accessManager = new ClashAccessManager();
            retVal = accessManager.SearchForClans(term); 
            return retVal;
        }
    }
}
