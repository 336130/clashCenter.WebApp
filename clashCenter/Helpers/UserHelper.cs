using clashCenter.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace clashCenter.Helpers
{
    public static class UserHelper
    {
        private static BusinessManager _businessManager { get { return new BusinessManager(); } }
        public static string UserId
        {
            get
            {
                var authToken = HttpContext.Current.Request.Headers["Authorization"].Replace("Bearer ", "");
                return _businessManager.GetUserIdFromToken(authToken);
            }
        }
    }
}
