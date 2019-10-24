using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MFA.Server.Domain;
using MFA.Server.Repositories;
using MFA.Shared.DTOs;

namespace MFA.Server.Services
{
    public class UserService: IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(
            IUserRepository userRepository,
            IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        
        public async Task<UserDto> GetUser(string email)
        {
            var user = await _userRepository.GetUser(email);
            return _mapper.Map<User, UserDto>(user);
        }

        public async Task<UserDto> GetUser(Guid id)
        {
            var user = await _userRepository.GetUser(id);
            return _mapper.Map<User, UserDto>(user);
        }

        public async Task<IEnumerable<UserDto>> GetAllUsers()
        {
            var users = await _userRepository.GetAllUsers();
            return _mapper.Map<IEnumerable<User>, IEnumerable<UserDto>>(users);
        }

        public async Task AddUser(User user)
        {
            await _userRepository.AddUser(user);
        }

        public async Task RemoveUser(Guid id)
        {
            await _userRepository.RemoveUser(id);
        }

        public async Task UpdateUser(User user)
        {
            await _userRepository.UpdateUser(user);
        }
    }
}