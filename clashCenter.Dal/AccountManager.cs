using clashCenter.Dal.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.DataProtection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace clashCenter.Dal
{
    public class AccountManager
    {
        private UserManager<IdentityUser> _userManager { get; set; }
        private UserManager<IdentityUser> UserManager
        {
            get
            {
                if (_userManager == null)
                {
                    var provider = new DpapiDataProtectionProvider("ClashCenter");
                    _userManager = new UserManager<IdentityUser>(new UserStore<IdentityUser>());
                    _userManager.UserTokenProvider = new DataProtectorTokenProvider<IdentityUser>(provider.Create("authorisation"));
                }
                return _userManager;
            }
        }

        private IAuthenticationManager _authenticationManager
        {
            get
            {
                return HttpContext.Current.GetOwinContext().Authentication;
            }
        }

        private IdentityUser _currentUser
        {
            get
            {
                var claim = _authenticationManager?.User?.Claims.FirstOrDefault(c => c.Type == "username");
                var user = claim != null ? UserManager.FindByName(claim.Value) : null; ;
                return user;
            }
        }

        public IdentityUser GetUser()
        {
            return _currentUser;
        }

        public IdentityUser GetUser(string email, string password)
        {
            return UserManager.Find(email, password);
        }

        public bool CreateUser(string username, string password)
        {
            var manager = UserManager;

            var newUser = new IdentityUser() { UserName = username };
            IdentityResult result = manager.Create(newUser, password);

            if (result.Succeeded)
            {
                var userIdentity = manager.CreateIdentity(newUser, DefaultAuthenticationTypes.ExternalBearer);
                    _authenticationManager.SignIn(
                                              new AuthenticationProperties() { },
                                              userIdentity);
            }

            return result.Succeeded;
        }

        public string GetUsername()
        {
            return _currentUser?.UserName;
        }

        public string GetUserID()
        {
            return _currentUser?.Id;
        }

        public List<Favorite> GetUserDetails()
        {
            return new DatabaseAccessManager().GetFavorites(GetUserID());
        }

        public void LogoutUser()
        {
            _authenticationManager.SignOut();
        }
    }
}

