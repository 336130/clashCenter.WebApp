using clashCenter.Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using clashCenter.Dal.Models.ClashResponse;
using Location = clashCenter.Dal.Location;
using clashCenter.Dal.Models;

namespace clashCenter.Business
{
    public class BusinessManager
    {
        public BusinessManager()
        {

        }

        #region Clan
        public ClanSearchResults SearchForClan(string name,string warFrequency, int minMembers,int maxMembers, int minClanPoints, int minClanLevel, int location,string userId)
        {
            List<Parameter> par = new List<Parameter>();
            par.Add(new Parameter { key = "name=", value = name });
            par.Add(new Parameter { key = "warFrequency=", value = warFrequency });
            par.Add(new Parameter { key = "minMembers=", value = minMembers.ToString() });
            par.Add(new Parameter { key = "maxMembers=", value = maxMembers.ToString() });
            par.Add(new Parameter { key = "minClanPoints=", value = minClanPoints.ToString() });
            par.Add(new Parameter { key = "minClanLevel=", value = minClanLevel.ToString() });
            par.Add(new Parameter { key = "location=", value = location.ToString() });

            par.RemoveAll(p => string.IsNullOrWhiteSpace(p.value) || p.value == "0");

            return new ClashAccessManager().SearchForClans(par, userId);
        }

        public Dal.Models.ClashResponse.Clan GetClan(string clanTag)
        {
            return new ClashAccessManager().GetAndSaveFullClanDetails(clanTag);
        }

        public ClanWithHistory GetClanWithHistory(string userId,string tag)
        {
            return new ClashAccessManager().GetClanWithHistory(userId,tag);
        }
        #endregion

        #region Favorites
        public bool AddFavorite(string tag, string userId)
        {
            return new DatabaseAccessManager().AddFavorite(tag, userId);
        }

        public bool AddInterest(string tag, string userId)
        {
            return new DatabaseAccessManager().AddInterest(tag, userId);
        }
        public bool RemoveFavorite(string tag, string userId)
        {
            return new DatabaseAccessManager().RemoveFavorite(tag, userId);
        }

        public bool RemoveInterest(string tag, string userId)
        {
            return new DatabaseAccessManager().RemoveInterest(tag, userId);
        }
        #endregion

        #region Locations
        public List<Location> GetLocations()
        {
            return new DatabaseAccessManager().GetLocations();
        }
        #endregion

        #region Account
        public string CreateUser(string username, string password)
        {
            return new AccountManager().CreateUser(username, password);
        }

        public string LoginUser(string email, string password)
        {
            return new AccountManager().LoginUser(email, password);
        }

        public bool LogoutUser(string token)
        {
            return new AccountManager().LogoutUser(token);
        }

        public string GetUserIdFromToken(string token)
        {
            return new AccountManager().GetUserIDFromToken(token);
        }

        public string GetUsernameFromUserId(string userId)
        {
            return new AccountManager().GetUsernameFromUserId(userId);
        }

        public string UpdateTokenExpiry(string token)
        {
            return new AccountManager().UpdateTokenExpiry(token);
        }

        public List<Favorite> GetUserDetails(string token)
        {
            return new AccountManager().GetUserDetails(token);
        }
        #endregion
    }
}
