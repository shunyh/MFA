using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MFA.Shared.Validation
{
    public static class UserValidator
    {
        public static void ValidateUserEmail(this string email)
        {
            if (!Regex.IsMatch(email, ValidationRegex.EmailRegex))
                throw new Exception("Email is invalid");
        }
        
        public static void ValidateUserPassword(this string password)
        {
            if (!Regex.IsMatch(password, ValidationRegex.PasswordRegex))
                throw new Exception("Password is invalid");
        }
    }
}