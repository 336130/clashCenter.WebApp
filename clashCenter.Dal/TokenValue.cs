using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clashCenter.Dal
{
    public class TokenValue
    {
        public TokenValue(string userid)
        {
            UserId = userid;
            LastUsed = DateTime.Now;
        }
        public string UserId { get; set; }
        public DateTime LastUsed { get; set; }
    }
}
