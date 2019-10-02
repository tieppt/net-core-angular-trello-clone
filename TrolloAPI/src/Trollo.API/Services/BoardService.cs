using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Trollo.Common.ViewModels;
using TrolloAPI.Data;
using TrolloAPI.Data.Entities;
using TrolloAPI.Services.Contracts;

namespace TrolloAPI.Services
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