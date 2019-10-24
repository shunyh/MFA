using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MFA.Server.Domain
{
    public class User
    {
        public Guid Id { get; protected set; }
        public string Email { get; protected set; }
        public string Salt { get; protected set; }
        public string PasswordHash { get; protected set; }
        public string TotpSecretKey { get; protected set; }

        public User(string email, string salt, string passwordHash, string totpSecretKey)
        {
            Id= Guid.NewGuid();
            Email = email;
            Salt = salt;
            PasswordHash = passwordHash;
            TotpSecretKey = totpSecretKey;
        }
    }
}