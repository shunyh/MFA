using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MFA.Shared.DTOs;

namespace MFA.Server.Services
{
    public interface IAuthService
    {
        Task<LoginResponseDto> Login(string email, string password, string totpCode);
        Task<RegisterResponseDto> RegisterUser(string email, string password);
    }
}