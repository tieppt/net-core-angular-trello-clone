using System;
using System.Net;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Trollo.Common.Exceptions;
using Trollo.Common.Services.Contracts;
using Trollo.Common.ViewModels;

namespace Trollo.Common.Services
{
    public sealed class ExceptionResultBuilder : IExceptionResultBuilder
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ILogger<ExceptionResultBuilder> _logger;

        public ExceptionResultBuilder(IWebHostEnvironment webHostEnvironment, ILogger<ExceptionResultBuilder> logger)
        {
            _webHostEnvironment = webHostEnvironment;
            _logger = logger;
        }

        public IActionResult Build(Exception exception)
        {
            var stackTrace = "No stack trace available";

            if (!string.Equals(_webHostEnvironment.EnvironmentName, Environments.Production,
                StringComparison.OrdinalIgnoreCase))
            {
                stackTrace = exception.GetBaseException().StackTrace;
            }

            var statusCode = HttpStatusCode.InternalServerError;
            var content = string.Empty;
            var message = exception.GetBaseException().Message;

            switch (exception)
            {
                case NotFoundException _:
                    return new NotFoundResult();
                case ApiException apiException:
                {
                    statusCode = apiException.StatusCode;
                    content = apiException.GetContent();
                    if (!string.IsNullOrEmpty(apiException.Message))
                    {
                        message = apiException.GetBaseException().Message;
                    }

                    break;
                }
            }

            return CreateActionResult(content, message, stackTrace, statusCode, exception);
        }

        private IActionResult CreateActionResult(string content, string message, string stackTrace,
            HttpStatusCode statusCode, Exception exception)
        {
            var apiError = new ApiError
            {
                Error = content ?? message,
                StackTrace = stackTrace
            };

            var objectResult = new ObjectResult(apiError)
            {
                StatusCode = (int) statusCode
            };
            var eventId = new EventId((int) statusCode);
            _logger.LogError(eventId, exception, message);
            return objectResult;
        }
    }
}