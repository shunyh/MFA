using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MFA.Shared.Validation
{
    public class LoginValidationModel
    {
        [Required]
        [RegularExpression(ValidationRegex.EmailRegex, ErrorMessage = "Invalid Email")]
        public string Email { get; set; }
        
        [Required]
        [RegularExpression(ValidationRegex.PasswordRegex, ErrorMessage = "Invalid Password")]
        public string Password { get; set; }
        
        [Required]
        public string TotpCode { get; set; }
    }
}