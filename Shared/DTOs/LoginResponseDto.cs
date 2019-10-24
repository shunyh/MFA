using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MFA.Shared.DTOs
{
    public class LoginResponseDto
    {
        public string JwtToken { get; set; }
        public RefreshTokenDto RefreshToken { get; set; }
        public UserDto UserDto { get; set; }
    }
}