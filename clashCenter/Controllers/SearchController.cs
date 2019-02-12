using clashCenter.Business;
using clashCenter.Dal.Models.ClashResponse;
using clashCenter.Web.Models.RecieveObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace clashCenter.Controllers
{
    public class SearchController : ApiController
    {
        private BusinessManager _businessManager;

        [HttpPost]
        public ClanSearchResults SearchForClan (ClanSearch searchParams)
        {
            _businessManager = new BusinessManager();
            var auth = HttpContext.Current.Request.Headers["Authorization"];
            var userId = _businessManager.GetUsernameFromToken(auth.Replace("Bearer ",""));
            var retVal =_businessManager.SearchForClan(searchParams.name,
                                                            searchParams.warFrequency,
                                                            searchParams.minMembers,
                                                            searchParams.maxMembers,
                                                            searchParams.minClanPoints,
                                                            searchParams.minClanLevel,
                                                            searchParams.location,
                                                            userId
                                                            );
            return retVal;
        }
    }
}
