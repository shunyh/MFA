namespace MFA.Shared.Validation
{
    public static class ValidationRegex
    {
        public const string EmailRegex = @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$";
        public const string PasswordRegex = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[!@#\$%\^&\*]).{8,32}$";
        public const string TotpCode = @"^(?=.*[0-9]).{6}$";
    }
}