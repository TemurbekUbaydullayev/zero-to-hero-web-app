using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace ZeroToHero.Application.Common.Attributes;

[AttributeUsage(AttributeTargets.Property)]
public class AllowedFileExtensions : ValidationAttribute
{
    private readonly string[] _extensions;

    public AllowedFileExtensions(string[] extensions)
    {
        _extensions = extensions;
    }

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        var file = value as IFormFile;

        if (file is not null)
        {
            var extension = Path.GetExtension(file.FileName);

            if (_extensions.Contains(extension))
                return ValidationResult.Success;
            else
                return new ValidationResult("This file extension invalid!");
        }
        else
            return ValidationResult.Success;
    }
}