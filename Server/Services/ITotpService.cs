using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MFA.Server.Domain;

namespace MFA.Server.Services
{
    public interface ITotpService
    {
        string GenerateSecretKey();
        string GenerateTotpCode(User user);
        bool VerifyTotpCode(User user, string totpCode);
        string GenerateQrCode(User user);
    }
}