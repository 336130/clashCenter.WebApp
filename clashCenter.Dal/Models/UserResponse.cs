using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clashCenter.Dal.Models
{
    public class UserResponse
    {
        public UserResponse()
        {

        }
        public UserResponse(bool error, string errors, string token)
        {
            Error = error;
            Errors = Errors;
            Token = token;
        }
        public bool Error { get; set; }
        public string Errors { get; set; }
        public string Token { get; set; }
    }
}
