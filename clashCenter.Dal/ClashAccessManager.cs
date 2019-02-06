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
        public ClanSearchResults SearchForClans(string name)
        {
            string url = "clans" + FormatParameters(new string[] { "name=" + name });
            var responseFromServer = MakeWebRequest(url, _clanSearchKey);
            var retVal =  JsonConvert.DeserializeObject<ClanSearchResults>(responseFromServer);
            //GetAndSaveFullClanDetails(retVal.items);
            return retVal;
        }

        #region SaveDetails
        public void GetAndSaveFullClanDetails(List<ClanSearchResultsClan> clans)
        {
            foreach (var clan in clans)
            {
                GetAndSaveFullClanDetails(clan);
            }
        }
        #endregion

        public void GetAndSaveFullClanDetails(ClanSearchResultsClan clan)
        {
            Task.Run(() =>
            {
                string url = "clans/" + HttpUtility.UrlEncode(clan.Tag);
                var responseFromServer = MakeWebRequest(url, _clanKey);
                var retVal = JsonConvert.DeserializeObject<Models.ClashResponse.Clan>(responseFromServer);
                new DatabaseAccessManager().SaveClanInfo(retVal);
            });
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
