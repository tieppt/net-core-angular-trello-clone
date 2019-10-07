using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Trollo.API.Data.Entities;
using Trollo.Common.ViewModels;

namespace Trollo.API.Services.Contracts
{
    public interface IBoardService
    {
        Task<List<BoardVm>> GetAll(Guid userId);
        Task<BoardVm> Create(Board board);
        
        Task<BoardVm> Update(Guid userId, Board board);
    }
}
