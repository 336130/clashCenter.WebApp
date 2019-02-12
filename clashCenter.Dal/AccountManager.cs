using clashCenter.Dal.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
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
    public  class AccountManager
    {
        private UserManager<IdentityUser> _userManager { get; set; }
        private UserManager<IdentityUser> GetUserManager()
        {
            if (_userManager == null)
            {
                var provider = new DpapiDataProtectionProvider("ClashCenter");
                _userManager = new UserManager<IdentityUser>(new UserStore<IdentityUser>());
                _userManager.UserTokenProvider = new DataProtectorTokenProvider<IdentityUser>(provider.Create("authorisation"));
            }
            return _userManager;
        }
        
        public string CreateUser(string username, string password)
        {
            var manager = GetUserManager();

            var newUser = new IdentityUser() { UserName = username};
            IdentityResult result = manager.Create(newUser, password);

            if (result.Succeeded)
            {
                return LoginUser(username, password);
            }

            return "";
        }
        
        public string LoginUser(string email, string password)
        {
            var retVal = "";
            var manager = GetUserManager();
            var user = manager.Find(email, password);

            if (user != null)
            {
                retVal = manager.GenerateUserToken("login", user.Id);
                TokenCache.Tokens.Add(retVal, new TokenValue(user.Id));
            }
            DisposeOfOldTokens();
            return retVal;
        }

        public string GetUserIDFromToken(string token)
        {
            TokenValue tokenValue;
            string retVal = ""; ;
            if (TokenCache.Tokens.TryGetValue(token, out tokenValue))
            {
                if (tokenValue.LastUsed > DateTime.Now.AddDays(-14)){
                    retVal = tokenValue.UserId;
                }
                else
                {
                    TokenCache.Tokens.Remove(token);
                }
            }
            return retVal;
        }

        public void DisposeOfOldTokens()
        {
            Task.Run(() => {
                List<string> oldTokens = TokenCache.Tokens.Where(t => t.Value.LastUsed < DateTime.Now.AddDays(-14)).Select(t => t.Key).ToList();
                foreach (string token in oldTokens)
                {
                    TokenCache.Tokens.Remove(token);
                }
            });
        }

        public string UpdateTokenExpiry(string token)
        {
            TokenValue tokenValue;
            string retVal = "";
            if (TokenCache.Tokens.TryGetValue(token,out tokenValue))
            {
                retVal = token;
                tokenValue.LastUsed = DateTime.Now;
            }
            return retVal;
        }

        public bool LogoutUser(string token)
        {
            if (TokenCache.Tokens.ContainsKey(token)){
                 return TokenCache.Tokens.Remove(token);
            }
            return true;
        }
    }
}
