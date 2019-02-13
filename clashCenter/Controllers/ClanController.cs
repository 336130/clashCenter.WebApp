﻿using clashCenter.Business;
using clashCenter.Helpers;
using clashCenter.Models.RecieveObjects;
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
        public bool AddFavorite(FavoriteRequest request)
        {
            return _businessManager.AddFavorite(request.tag, UserHelper.UserId);
        }

        [HttpPost]
        public bool AddInterest(FavoriteRequest request)
        {
            return _businessManager.AddInterest(request.tag, UserHelper.UserId);
        }

        [HttpPost]
        public bool RemoveFavorite(FavoriteRequest request)
        {
            return _businessManager.RemoveFavorite(request.tag, UserHelper.UserId);
        }

        [HttpPost]
        public bool RemoveInterest(FavoriteRequest request)
        {
            return _businessManager.RemoveInterest(request.tag, UserHelper.UserId);
        }
    }
}