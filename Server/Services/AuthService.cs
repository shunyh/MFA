using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MFA.Server.Domain;
using MFA.Server.Repositories;
using MFA.Shared.DTOs;
using MFA.Shared.Validation;

namespace MFA.Server.Services
{
    public class AuthService: IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IEncrypter _encrypter;
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;
        private readonly ITotpService _totpService;

        public AuthService(
            IUserRepository userRepository,
            IEncrypter encrypter,
            ITokenService tokenService,
            IMapper mapper,
            ITotpService totpService)
        {
            _userRepository = userRepository;
            _encrypter = encrypter;
            _tokenService = tokenService;
            _mapper = mapper;
            _totpService = totpService;
        }
        
        public async Task<LoginResponseDto> Login(string email, string password, string totpCode)
        {
            var user = await _userRepository.GetUser(email);
            if(user == null)
                throw new Exception("User does not exist");

            var hash = _encrypter.GetHash(password, user.Salt);
            

            if (user.PasswordHash == hash && _totpService.VerifyTotpCode(user, totpCode))
            {
                var jwtToken = _tokenService.GenerateJwtToken(user);

                var token = _encrypter.GetSecureSalt(32);
                var refreshToken = new RefreshToken(token, DateTime.UtcNow.AddDays(1).Ticks.ToString());

                return new LoginResponseDto
                {
                    JwtToken = jwtToken,
                    RefreshToken = _mapper.Map<RefreshToken, RefreshTokenDto>(refreshToken),
                    UserDto = _mapper.Map<User, UserDto>(user)
                };
            }
            
            throw new Exception("Invalid credentials");
        }

        public async Task<RegisterResponseDto> RegisterUser(string email, string password)
        {
            var user = await _userRepository.GetUser(email);

            if (user != null)
            {
                throw new Exception("User already exist");
            }
            
            email.ValidateUserEmail();
            password.ValidateUserPassword();

            var salt = _encrypter.GetSecureSalt(32);
            var passwordHash = _encrypter.GetHash(password, salt);

            var totpSecretKey = _totpService.GenerateSecretKey();
            
            user = new User(email,salt,passwordHash, totpSecretKey);

            await _userRepository.AddUser(user);

            return new RegisterResponseDto
            {
                QrCode = _totpService.GenerateQrCode(user)
            };
        }
    }
}