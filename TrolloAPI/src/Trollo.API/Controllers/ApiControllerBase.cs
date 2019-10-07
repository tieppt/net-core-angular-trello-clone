using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Trollo.Common.Exceptions;

namespace Trollo.API.Controllers
{
    public abstract class ApiControllerBase : Controller
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
                if (!ModelState.IsValid)
                {
                    var errorList = ModelState.ToDictionary(
                        kvp => kvp.Key,
                        kvp => kvp.Value.Errors.Select(e =>
                            string.IsNullOrEmpty(e.ErrorMessage)
                                ? e.Exception?.GetBaseException().Message
                                : e.ErrorMessage).ToArray()
                    );

                    throw new ApiException<IDictionary<string, string[]>>("Invalid request", errorList);
                }

            base.OnActionExecuting(context);
        }
    }
}