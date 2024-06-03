using System.ComponentModel.DataAnnotations;
using ZeroToHero.Application.Validators;

namespace ZeroToHero.Application.Common.Attributes;

[AttributeUsage(AttributeTargets.Property)]
public class PasswordAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        var password = value as string;

        if (password is null) return new ValidationResult("Password required!");

        if (password.Length < 8)
            return new ValidationResult("Password must be more than 8 characters!");
        if (password.Length > 16)
            return new ValidationResult("Password must be less than 16 characters!");

        return password.IsStrong().isValid ? ValidationResult.Success
               : new ValidationResult(password.IsStrong().message);
    }
}