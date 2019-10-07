using System.Net;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using Trollo.Common.ViewModels;

namespace Trollo.API.Controllers.V1
{
    [SwaggerResponse(HttpStatusCode.NotFound, typeof(void))]
    [SwaggerResponse(HttpStatusCode.BadRequest, typeof(ApiError))]
    [SwaggerResponse(HttpStatusCode.InternalServerError, typeof(ApiError))]
    [Route("api/v1")]
    public abstract class ClientV1ControllerBase : ApiControllerBase
    {
    }
}