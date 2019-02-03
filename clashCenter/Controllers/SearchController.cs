using clashCenter.Business;
using clashCenter.Dal.Models;
using clashCenter.DAL.Models;
using clashCenter.Web.Models.RecieveObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace clashCenter.Controllers
{
    public class SearchController : ApiController
    {
        [HttpPost]
        public ClanList SearchForClan ([FromBody]ClanSearch searchParams)
        {
            var retVal = new BusinessManager().SearchForClan(searchParams.name);
            return retVal;
        }
    }
}
