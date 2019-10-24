using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MFA.Server.Settings
{
    public class DbSettings
    {
        public string ConnectionString { get; set; }
        public bool InMemory { get; set; }
        public bool Seed { get; set; }
    }
}