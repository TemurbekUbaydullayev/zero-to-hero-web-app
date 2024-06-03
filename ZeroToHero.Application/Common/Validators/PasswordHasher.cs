using System.Text.RegularExpressions;

namespace ZeroToHero.Application.Validators;

public static class PasswordValidator
{
    public static (bool isValid, string message) IsStrong(this string password)
    {
        if (!Regex.IsMatch(password, @"^(?=.*[a-z])"))
            return (false, "Password must contain at leas 1 small letter!");
        else if (!Regex.IsMatch(password, @"^(?=.*[A-Z])"))
            return (false, "Password must contain at leas 1 capital letter!");
        else if (!Regex.IsMatch(password, @"^(?=.*\d)"))
            return (false, "Password must contain at leas 1 digit!");
        else if (!Regex.IsMatch(password, @"(?=.*[!@#$%^&*()-_+=])"))
            return (false, "Password must contain at leas 1 special character!");

        return (true, "");
    }
}