using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MFA.Server.Domain;
using Microsoft.EntityFrameworkCore;

namespace MFA.Server.Repositories
{
    public class UserRepository: IUserRepository
    {
        private readonly MfaContext _context;
        
        public UserRepository(MfaContext context)
        {
            _context = context;
        }
        
        public async Task<User> GetUser(Guid id)
        {
            return await _context.Users.SingleOrDefaultAsync(u => u.Id == id);
        }

        public async Task<User> GetUser(string email)
        {
            return await _context.Users.SingleOrDefaultAsync(u => u.Email == email);
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task AddUser(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveUser(Guid id)
        {
            var user = await GetUser(id);
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateUser(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}