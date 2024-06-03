using System.Net;

namespace ZeroToHero.Application.Common.Exceptions;

public class ValidatorException : StatusCodeExeption
{
    public ValidatorException(string message)
        : base(HttpStatusCode.BadRequest, message)
    {
    }
}
