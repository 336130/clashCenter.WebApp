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
        public UserResponse(bool error, string errors, string message)
        {
            Error = error;
            Errors = errors;
            Message = message;
        }
        public bool Error { get; set; }
        public string Errors { get; set; }
        public string Message { get; set; }
    }
}
