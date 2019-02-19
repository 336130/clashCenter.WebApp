using clashCenter.Business;
using clashCenter.Dal.Models.ClashResponse;
using clashCenter.Helpers;
using clashCenter.Models.RecieveObjects;
using clashCenter.Models.ResponseObjects;
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
        private BusinessManager _businessManager { get { return new BusinessManager(); } }

        [HttpPost]
        public ClanSearchResults SearchForClan(ClanSearch searchParams)
        {
            var retVal = _businessManager.SearchForClan(searchParams.name,
                                                   searchParams.warFrequency,
                                                   searchParams.minMembers,
                                                   searchParams.maxMembers,
                                                   searchParams.minClanPoints,
                                                   searchParams.minClanLevel,
                                                   searchParams.location,
                                                   UserHelper.UserId
                                                   );
            retVal.items = retVal.items.OrderBy(c => c.IsFavorite).ToList();
            return retVal;
        }
    }
}
