using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TrolloAPI.Data;
using TrolloAPI.Data.Entities;
using TrolloAPI.Services.Contracts;

namespace TrolloAPI.Services
{
    public class BoardService : IBoardService
    {
        private AppDbContext _context;

        public BoardService(AppDbContext dbContext)
        {
            _context = dbContext;
        }
        public Task<List<Board>> GetAll(Guid userId)
        {

            var result = (from b in _context.Boards
                where b.UserId == userId
                select b).ToListAsync();
            return result;
        }
        public async Task<Board> Create(Board board)
        {
            await _context.AddAsync(board);
            await _context.SaveChangesAsync();
            return board;
        }
    }
}