using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeroToHero.Application.Common.Exceptions.Entity;

public class ErrorMessage
{
    public int StatusCode { get; set; }
    public string Message { get; set; } = string.Empty;
}