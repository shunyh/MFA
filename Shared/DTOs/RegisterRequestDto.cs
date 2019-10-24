using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using MFA.Shared.Validation;

namespace MFA.Shared.DTOs
{
    public class RegisterRequestDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}