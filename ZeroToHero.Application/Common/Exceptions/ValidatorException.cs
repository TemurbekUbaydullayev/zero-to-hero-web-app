using System.Net;

namespace ZeroToHero.Application.Common.Exceptions;

public class ValidatorException : StatusCodeException
{
    public ValidatorException(string message)
        : base(HttpStatusCode.BadRequest, message)
    {
    }
}
