using Microsoft.AspNetCore.Mvc;
using Trollo.Common.Contracts;

namespace Trollo.API.Controllers.V1
{
    public class StartController : ApiControllerBase
    {
        [HttpGet(ApiRoutes.RootIndex)]
        public IActionResult Index()
        {
            return Ok(new
            {
                message = "App works!"
            });
        }
    }
}