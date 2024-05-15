using TaskBoard.Domain.Entities;

namespace TaskBoard.Abstractions.Infrastructure
{
    public interface IListCardsRepository : IGenericRepository<ListCards>
    {
        Task<ListCards?> GetByNameAsync(string name);
        Task<ListCards?> GetByIdAsync(int id);
        Task<IEnumerable<ListCards?>> GetByBoardId(int id);
    }
}
