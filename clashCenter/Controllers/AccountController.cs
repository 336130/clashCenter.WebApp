using clashCenter.Business;
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
        public void LogoutUser()
        {
             new BusinessManager().LogoutUser();
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

            var userId = _businessManager.GetUserId();
            var favorites = _businessManager.GetUserDetails();
            var username = _businessManager.GetUsername();

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
