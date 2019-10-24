using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MFA.Server.Domain;
using MFA.Server.Settings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace MFA.Server
{
    public class MfaContext: DbContext
    {
        private readonly IOptions<DbSettings> _settings;
        
        public MfaContext(
            IOptions<DbSettings> settings,
            DbContextOptions<MfaContext> options)
            : base(options)
        {
            _settings = settings;
        }
        
        //DbSets
        public DbSet<User> Users { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            
            if (_settings.Value.InMemory)
            {
                optionsBuilder.UseInMemoryDatabase("InMemoryDb");
                return;
            }
            
            optionsBuilder.UseSqlServer(_settings.Value.ConnectionString);
        }
    }
}