using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MFA.Server.Domain;
using MFA.Shared.DTOs;

namespace MFA.Server.Services
{
    public interface IUserService
    {
        Task<UserDto> GetUser(string email);
        Task<UserDto> GetUser(Guid id);
        Task<IEnumerable<UserDto>> GetAllUsers();
        Task AddUser(User user);
        Task RemoveUser(Guid id);
        Task UpdateUser(User user);
    }
}