using clashCenter.Business;
using clashCenter.Dal;
using clashCenter.Models.ResponseObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace clashCenter.Controllers
{
    public class LocationController: ApiController
    {
        [HttpGet]
        public List<LocationViewModel> GetLocations()
        {
            return new BusinessManager().GetLocations().Select(loc => new LocationViewModel(loc)).ToList();
        }
    }
}
