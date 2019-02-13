using clashCenter.Dal.Models;
using clashCenter.Dal.Models.ClashResponse;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace clashCenter.Dal
{
    public class ClashAccessManager
    {
        private string _clashApi = ConfigurationManager.AppSettings["ClashApi"];

        private string _clanKey = ConfigurationManager.AppSettings["ClanKey"];
        private string _clanSearchKey = ConfigurationManager.AppSettings["ClanSearchKey"];

        #region clans
        public ClanSearchResults SearchForClans(List<Parameter> par,string userId)
        {
            string url = "clans" + FormatParameters(par.Select(p => p.key + p.value).ToArray());
            var responseFromServer = MakeWebRequest(url, _clanSearchKey);
            ClanSearchResults retVal = JsonConvert.DeserializeObject<ClanSearchResults>(responseFromServer);
            //GetAndSaveFullClanDetails(retVal.items);
            if (userId != null)
            {
                GetFavoritesAndInterestsForUser(userId, retVal);
            }
            return retVal;
        }

        private void GetFavoritesAndInterestsForUser(string userId, ClanSearchResults results)
        {
            using (var dbContext = new ClashCenterEntities())
            {
                for (var i = 0; i < results.items.Count(); i++)
                {
                    var clan = results.items[i];
                    if (dbContext.CurrentFavorites.Any(f => f.UserId == userId && f.ClashTargetId == clan.Tag))
                    {
                        var favorite = dbContext.CurrentFavorites.FirstOrDefault(f => f.UserId == userId && f.ClashTargetId == clan.Tag);
                        clan.IsFavorite = true;
                        clan.IsInterest = favorite.IsInterest;
                    }
                }
            }
        }
        #endregion

        #region SaveDetails
        public void GetAndSaveFullClanDetails(List<ClanSearchResultsClan> clans)
        {
            foreach (var clan in clans)
            {
                Task.Run(() =>
                {
                    GetAndSaveFullClanDetails(clan.Tag);
                });
            }
        }

        public Models.ClashResponse.Clan GetAndSaveFullClanDetails(string clanTag)
        {
            string url = "clans/" + HttpUtility.UrlEncode(clanTag);
            var responseFromServer = MakeWebRequest(url, _clanKey);
            var retVal = JsonConvert.DeserializeObject<Models.ClashResponse.Clan>(responseFromServer);
            new DatabaseAccessManager().SaveClanInfo(retVal);
            return retVal;
        }
        #endregion

        #region HelperMethods
        private string MakeWebRequest(string url, string authKey)
        {
            var webRequest = WebRequest.Create(_clashApi + url);
            webRequest.Headers.Add("authorization", "Bearer " + authKey);
            using (var response = webRequest.GetResponse())
            {
                return new StreamReader(response.GetResponseStream()).ReadToEnd();
            }
        }

        private string FormatParameters(params string[] parameters)
        {
            if (parameters.Any())
            {
                return "?" + string.Join("&", parameters);
            }
            return "";
        }
        #endregion
    }
}
