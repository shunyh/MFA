using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MFA.Server.Domain;

namespace MFA.Server.Services
{
    public interface ITokenService
    {
        string GenerateJwtToken(User user);
        string GenerateRefreshToken();
    }
}