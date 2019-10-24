using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MFA.Shared.Validation
{
    public class RegisterValidationModel
    {
        [Required]
        [RegularExpression(ValidationRegex.EmailRegex, ErrorMessage = "Invalid Email")]
        public string Email { get; set; }
        
        [Required]
        [RegularExpression(ValidationRegex.PasswordRegex, ErrorMessage = "Invalid Password")]
        public string Password { get; set; }
        
        [Required]
        [Compare("Password", ErrorMessage = "Password are not same")]
        public string RepeatPassword { get; set; }
    }
}