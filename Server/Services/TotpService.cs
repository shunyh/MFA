using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MFA.Server.Domain;
using MFA.Server.Repositories;
using OtpNet;
using QRCoder;

namespace MFA.Server.Services
{
    public class TotpService: ITotpService
    {
        public TotpService()
        {
            
        }
        
        public string GenerateSecretKey()
        {
            var key = KeyGeneration.GenerateRandomKey(OtpHashMode.Sha1);

            return Base32Encoding.ToString(key);
        }

        public string GenerateTotpCode(User user)
        {
            var totpSecretKey = Base32Encoding.ToBytes(user.TotpSecretKey);
            var totp = new Totp(totpSecretKey);
            return totp.ComputeTotp();
        }

        public bool VerifyTotpCode(User user, string totpCode)
        {
            long timeStep;
            var window = new VerificationWindow(previous:1, future:1);

            var totpSecretKey = Base32Encoding.ToBytes(user.TotpSecretKey);
            var totp = new Totp(totpSecretKey);

            return totp.VerifyTotp(totpCode, out timeStep, window);
        }

        public string GenerateQrCode(User user)
        {
            var uri = string.Format("otpauth://totp/{0}?secret={1}&issuer={2}", user.Email, user.TotpSecretKey, "MFA");
            var qrGenerator = new QRCodeGenerator();
            var qrCodeData = qrGenerator.CreateQrCode(uri, QRCodeGenerator.ECCLevel.Q);
            var qrCode = new Base64QRCode(qrCodeData);
            var qrCodeImageAsBase64 = qrCode.GetGraphic(20);
            return qrCodeImageAsBase64;
        }
    }
}