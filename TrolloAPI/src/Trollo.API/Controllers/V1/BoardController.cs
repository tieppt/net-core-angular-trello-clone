using System;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Trollo.Common.Contracts.Requests;
using Trollo.Common.Services.Contracts;
using TrolloAPI.Data.Entities;
using TrolloAPI.Services.Contracts;

namespace TrolloAPI.Controllers.V1
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class BoardController: ClientV1ControllerBase
    {
        private readonly IBoardService _boardService;
        private readonly IServiceInvoker _serviceInvoker;
        
        public BoardController(IBoardService boardService, IServiceInvoker serviceInvoker)
        {
            _boardService = boardService;
            _serviceInvoker = serviceInvoker;
        }
        
        [HttpGet("[controller]")]
        public Task<IActionResult> GetAll()
        {
            var userId = new Guid(User.FindFirstValue("id"));
            return _serviceInvoker.AsyncOk(() => _boardService.GetAll(userId));
        }

        [HttpPost("[controller]")]
        public Task<IActionResult> Create([FromBody] CreateBoardRequest createBoardRequest)
        {
            var userId = new Guid(User.FindFirstValue("id"));
            var board = new Board
            {
                UserId = userId,
                Title = createBoardRequest.Title,
                Scope = "public",
                Status = "publish"
            };
            return _serviceInvoker.AsyncOk(() => _boardService.Create(board));
        }
    }
}
