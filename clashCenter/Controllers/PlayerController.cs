using clashCenter.Web.Models.RecieveObjects;
using clashCenter.Web.Models.ResponseObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace clashCenter.Web.Controllers
{
    public class PlayerController : ApiController
    {
        [HttpPost]
        public PlayerNameResponse PlayerName([FromBody]string player)
        {   
            var retVal = new PlayerNameResponse();
            retVal.Name = player + " result!";
            return retVal;
        }
    }
}
