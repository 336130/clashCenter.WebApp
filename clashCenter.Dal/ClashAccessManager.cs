using clashCenter.Dal.Models;
using clashCenter.DAL.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace clashCenter.Dal
{
    public class ClashAccessManager
    {
        private string _clashApi = ConfigurationManager.AppSettings["ClashApi"];
        private string _locationKey = ConfigurationManager.AppSettings["LocationKey"];

        public ClanList SearchForClans(string name)
        {
            string url = "clans" + FormatParameters(new string[] { "name=" + name });
            var responseFromServer = MakeWebRequest(url,_locationKey);
            return JsonConvert.DeserializeObject<ClanList>(responseFromServer);
        }

        #region HelperMethods
        private string MakeWebRequest(string url,string authKey)
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
