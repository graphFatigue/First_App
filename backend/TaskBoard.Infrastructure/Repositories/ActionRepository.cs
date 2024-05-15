using Microsoft.EntityFrameworkCore;
using Sieve.Services;
using TaskBoard.Abstractions.Infrastructure;
using Action = TaskBoard.Domain.Entities.Action;

namespace TaskBoard.Infrastructure.Repositories
{
    public class ActionRepository : GenericRepository<Action>, IActionRepository
    {
        public ActionRepository(
            AppDbContext context,
            ISieveProcessor sieveProcessor) : base(context, sieveProcessor)
        {
        }

        public async Task<IEnumerable<Action>> GetAllByCardIdAsync(int cardId)
        {
            return await _dbSet.Where(c => c.CardId == cardId).OrderByDescending(c => c.ActionTime).ToListAsync();
        }

        public async Task<Action?> GetByIdAsync(int id)
        {
            return await _dbSet.FirstOrDefaultAsync(e => e.Id == id);
        }
    }
}
