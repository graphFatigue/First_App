using TaskBoard.Domain.Entities;

namespace TaskBoard.Abstractions.Infrastructure
{
    public interface ICardRepository : IGenericRepository<Card>
    {
        Task<Card?> GetByIdAsync(int id);
        Task<IEnumerable<Card?>> GetAllWithoutParentListAsync();
    }
}
