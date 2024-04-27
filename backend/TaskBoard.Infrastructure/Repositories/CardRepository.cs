using Microsoft.EntityFrameworkCore;
using Sieve.Services;
using TaskBoard.Abstractions.Infrastructure;
using TaskBoard.Domain.Entities;

namespace TaskBoard.Infrastructure.Repositories
{
    public class CardRepository : GenericRepository<Card>, ICardRepository
    {
        public CardRepository(
            AppDbContext context,
            ISieveProcessor sieveProcessor) : base(context, sieveProcessor)
        {
        }

        public async Task<Card?> GetByIdAsync(int id)
        {
            return await _dbSet.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<IEnumerable<Card?>> GetAllWithoutParentListAsync()
        {
            return await _dbSet.Where(c => c.ListCardsId == null).ToListAsync();
        }
    }
}
