using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TrolloAPI.Data.Entities;

namespace TrolloAPI.Services.Contracts
{
    public interface IBoardService
    {
        Task<List<Board>> GetAll(Guid userId);
        Task<Board> Create(Board board);
    }
}