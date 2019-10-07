using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using Trollo.Common.Contracts.Requests;
using Trollo.Common.Contracts.Responses;
using Trollo.Common.Services.Contracts;
using Trollo.Identity.Services.Contracts;

namespace Trollo.API.Controllers.V1
{
    public class AuthController : ClientV1ControllerBase
    {
        private readonly IIdentityService _identityService;
        private readonly IServiceInvoker _serviceInvoker;

        public AuthController(IIdentityService identityService, IServiceInvoker serviceInvoker)
        {
            _identityService = identityService;
            _serviceInvoker = serviceInvoker;
        }

        [HttpPost("[controller]/[action]")]
        [SwaggerResponse(HttpStatusCode.OK, typeof(AuthSuccessResponse))]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            return await _serviceInvoker.AsyncOk(() => _identityService.Register(request.Email, request.Password));
        }

        [HttpPost("[controller]/[action]")]
        [SwaggerResponse(HttpStatusCode.OK, typeof(AuthSuccessResponse))]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            return await _serviceInvoker.AsyncOk(() => _identityService.Login(request.Email, request.Password));
        }
    }
}