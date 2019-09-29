using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TrolloAPI.Contracts;
using TrolloAPI.Contracts.Requests;
using TrolloAPI.Contracts.Responses;
using TrolloAPI.Services.Contracts;

namespace TrolloAPI.Controllers
{
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IIdentityService _identityService;
        
        public AuthController(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        [HttpPost(ApiRoutes.Auth.Register)]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new AuthFailedResponse
                {
                    Errors = ModelState.Values.SelectMany(x => x.Errors.Select(xx => xx.ErrorMessage))
                });
            }
            
            var authResponse = await _identityService.RegisterAsync(request.Email, request.Password);

            if (!authResponse.Success)
            {
                return BadRequest(new AuthFailedResponse
                {
                    Errors = authResponse.Errors
                });
            }
            
            return Ok(new AuthSuccessResponse
            {
                Token = authResponse.Token,
            });
        }
        
        [HttpPost(ApiRoutes.Auth.Login)]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var authResponse = await _identityService.LoginAsync(request.Email, request.Password);

            if (!authResponse.Success)
            {
                return BadRequest(new AuthFailedResponse
                {
                    Errors = authResponse.Errors
                });
            }
            
            return Ok(new AuthSuccessResponse
            {
                Token = authResponse.Token,
            });
        }
    }
}