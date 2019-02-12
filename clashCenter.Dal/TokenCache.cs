using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clashCenter.Dal.Models
{
    public static class TokenCache
    {
        private static Dictionary<string, TokenValue> _tokens;
        public static Dictionary<string, TokenValue> Tokens {
            get
            {
                if (_tokens == null)
                {
                    _tokens = new Dictionary<string, TokenValue>();
                }
                return _tokens;
            }
        }
    }
}
