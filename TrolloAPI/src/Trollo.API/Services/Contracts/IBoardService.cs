using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Trollo.Common.ViewModels;
using TrolloAPI.Data.Entities;

namespace TrolloAPI.Services.Contracts
{
    public interface IBoardService
    {
        Task<List<BoardVm>> GetAll(Guid userId);
        Task<BoardVm> Create(Board board);
    }
}