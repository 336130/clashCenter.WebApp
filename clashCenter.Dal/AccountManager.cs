using clashCenter.Dal.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.DataProtection;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
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

        public UserResponse CreateUser(string username, string password)
        {
            var manager = UserManager;

            var newUser = new IdentityUser() { UserName = username };
            IdentityResult result = manager.Create(newUser, password);
            var tokenPath = "http://" + HttpContext.Current.Request.Url.Host + "/api/token";

            if (result.Succeeded)
            {
                var userIdentity = manager.CreateIdentity(newUser, DefaultAuthenticationTypes.ExternalBearer);

                tokenPath = "http://" + HttpContext.Current.Request.Url.Host + "/api/token";
                var data = $"grant_type=password&password={password}&username={username}";

                var request = WebRequest.Create(tokenPath);
                request.Method = "POST";
                var bodyStream = request.GetRequestStream();
                var queryBytes = Encoding.ASCII.GetBytes(data);
                bodyStream.Write(queryBytes, 0, queryBytes.Length);
                bodyStream.Close();

                using (var response = request.GetResponse())
                {
                    var stream = new StreamReader(response.GetResponseStream()).ReadToEnd();
                    var token = JsonConvert.DeserializeObject<TokenResponse>(stream);
                    return new UserResponse(false, "", token.access_token);
                }
            }

            return new UserResponse(true, $"Could not create user for {username}", "");
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

