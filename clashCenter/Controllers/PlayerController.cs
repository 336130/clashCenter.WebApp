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
        public void PlayerName([FromBody]string player)
        {   
        }
    }
}
