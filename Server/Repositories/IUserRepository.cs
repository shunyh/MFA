using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MFA.Server.Domain;

namespace MFA.Server.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetUser(Guid id);
        Task<User> GetUser(string email);
        Task<IEnumerable<User>> GetAllUsers();
        Task AddUser(User user);
        Task RemoveUser(Guid id);
        Task UpdateUser(User user);
        Task SaveChanges();
    }
}