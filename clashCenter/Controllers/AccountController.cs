﻿using clashCenter.Business;
using clashCenter.Helpers;
using clashCenter.Models.RecieveObjects;
using clashCenter.Models.ResponseObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace clashCenter.Controllers
{
    public class AccountController : ApiController
    {
        private BusinessManager _businessManager { get { return new BusinessManager(); } }

        [HttpPost]
        public UserResponseViewModel LoginUser(UserViewModel user)
        {
            return new UserResponseViewModel(false,null, new BusinessManager().LoginUser(user.Username,user.Password));
        }

        [HttpPost]
        public bool LogoutUser(string token)
        {
            return new BusinessManager().LogoutUser(token);
        }

        [HttpPost]
        public UserResponseViewModel Refresh()
        {
            var auth = HttpContext.Current.Request.Headers["Authorization"];
            var response = _businessManager.UpdateTokenExpiry(auth.Replace("Bearer ", ""));
            return new UserResponseViewModel(false,null,response );
        }

       [HttpPost]
       public UserResponseViewModel Register(UserViewModel user)
        {
            return new UserResponseViewModel(false,null, new BusinessManager().CreateUser(user.Username, user.Password));
        }

        [HttpPost]
        public UserDetailsResponseViewModel GetUserDetails()
        {
            var retVal = new UserDetailsResponseViewModel();

            var userId = UserHelper.UserId;
            var favorites = _businessManager.GetUserDetails(userId);
            var username = _businessManager.GetUsernameFromUserId(userId);

            retVal.UserID = userId;
            retVal.Username = username;
            foreach (var favorite in favorites)
            {
                retVal.Favorites.Add(new FavoriteViewModel(_businessManager.GetClan(favorite.ClashTargetID),favorite.IsInterest));
            }
            return retVal;
        }
    }
}