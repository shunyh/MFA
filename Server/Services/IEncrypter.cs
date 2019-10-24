using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MFA.Server.Services
{
    public interface IEncrypter
    {
        string GetSecureSalt(int size);
        string GetHash(string password, string salt);
    }
}