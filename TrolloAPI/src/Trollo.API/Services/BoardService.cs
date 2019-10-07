using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Trollo.API.Data;
using Trollo.API.Data.Entities;
using Trollo.API.Services.Contracts;
using Trollo.Common.ViewModels;

namespace Trollo.API.Services
{
    public class BoardService : IBoardService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public BoardService(AppDbContext dbContext, IMapper mapper)
        {
            _context = dbContext;
            _mapper = mapper;
        }

        public async Task<List<BoardVm>> GetAll(Guid userId)
        {
            var result = await _context.Boards
                .AsNoTracking()
                .Where(board => board.UserId == userId)
                .ToListAsync();
            return _mapper.Map<List<Board>, List<BoardVm>>(result);
        }

        public async Task<BoardVm> Create(Board board)
        {
            await _context.AddAsync(board);
            await _context.SaveChangesAsync();
            return _mapper.Map<BoardVm>(board);
        }
    }
}