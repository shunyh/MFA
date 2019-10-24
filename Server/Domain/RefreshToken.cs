using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MFA.Server.Domain
{
    public class RefreshToken
    {
        public string Token { get; protected set; }
        public string ExpireDate { get; protected set; }

        public RefreshToken(string token, string expireDate)
        {
            Token = token;
            ExpireDate = expireDate;
        }
    }
}