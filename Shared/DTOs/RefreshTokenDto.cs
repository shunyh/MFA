using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MFA.Shared.DTOs
{
    public class RefreshTokenDto
    {
        public string Token { get; protected set; }
        public string ExpireDate { get; protected set; }
    }
}