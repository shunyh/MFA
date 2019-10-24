using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MFA.Shared.DTOs
{
    public class LoginRequestDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Totp { get; set; }
    }
}