using clashCenter.Business;
using clashCenter.Dal.Models;
using clashCenter.Models.RecieveObjects;
using clashCenter.Models.ResponseObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace clashCenter.Controllers
{
    public class ClanController : ApiController 
    {
        private BusinessManager _businessManager { get { return new BusinessManager(); } }
        
        [HttpPost]
        public ClanWithHistoryViewModel GetClan(ClanRequest request)
        {
            return new ClanWithHistoryViewModel(_businessManager.GetClanWithHistory(_businessManager.GetUserId(),request.tag));
        }

        [HttpPost]
        public bool AddFavorite(FavoriteRequest request)
        {
            return _businessManager.AddFavorite(request.tag, _businessManager.GetUserId());
        }

        [HttpPost]
        public bool AddInterest(FavoriteRequest request)
        {
            return _businessManager.AddInterest(request.tag, _businessManager.GetUserId());
        }

        [HttpPost]
        public bool RemoveFavorite(FavoriteRequest request)
        {
            return _businessManager.RemoveFavorite(request.tag, _businessManager.GetUserId());
        }

        [HttpPost]
        public bool RemoveInterest(FavoriteRequest request)
        {
            return _businessManager.RemoveInterest(request.tag, _businessManager.GetUserId());
        }
    }
}
