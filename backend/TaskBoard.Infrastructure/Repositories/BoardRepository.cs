using Microsoft.EntityFrameworkCore;
using Sieve.Services;
using TaskBoard.Abstractions.Infrastructure;
using TaskBoard.Domain.Entities;

namespace TaskBoard.Infrastructure.Repositories
{
    public class BoardRepository : GenericRepository<Board>, IBoardRepository
    {
        public BoardRepository(
            AppDbContext context,
            ISieveProcessor sieveProcessor) : base(context, sieveProcessor)
        {
        }

        public async Task<Board?> GetByIdAsync(int id)
        {
            return await _dbSet.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<Board?> GetByNameAsync(string name)
        {
            return await _dbSet.FirstOrDefaultAsync(x => x.Name == name);
        }
    }
}
