﻿using Microsoft.EntityFrameworkCore;
using Sieve.Services;
using TaskBoard.Abstractions.Infrastructure;
using TaskBoard.Domain.Entities;

namespace TaskBoard.Infrastructure.Repositories
{
    public class ListCardsRepository : GenericRepository<ListCards>, IListCardsRepository
    {
        public ListCardsRepository(
            AppDbContext context,
            ISieveProcessor sieveProcessor) : base(context, sieveProcessor)
        {
        }

        public async Task<IEnumerable<ListCards?>> GetByBoardId(int id)
        {
            return await _dbSet.Where(x => x.Board.Id == id).ToListAsync();
        }

        public async Task<ListCards?> GetByIdAsync(int id)
        {
            return await _dbSet.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<ListCards?> GetByNameAsync(string name)
        {
            return await _dbSet.FirstOrDefaultAsync(x => x.Name == name);
        }
    }
}
