using System;
using Microsoft.AspNetCore.Mvc;

namespace Trollo.Common.Services.Contracts
{
    public interface IExceptionResultBuilder
    {
        IActionResult Build(Exception exception);
    }
}