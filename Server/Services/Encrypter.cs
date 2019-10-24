using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace MFA.Server.Services
{
    public class Encrypter: IEncrypter
    {
        public string GetSecureSalt(int size)
        {
            using (var rng = RandomNumberGenerator.Create())
            {
                var salt = new byte[size];
                rng.GetBytes(salt);
                return Convert.ToBase64String(salt);
            }
        }

        public string GetHash(string password, string salt)
        {
            var hash = KeyDerivation.Pbkdf2(
                password: password,
                salt: GetBytes(salt),
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 10000,
                numBytesRequested: 256 / 8);

            return Convert.ToBase64String(hash);
        }
        
        private byte[] GetBytes(string value)
        {
            return Encoding.UTF8.GetBytes(value);
        }
    }
}