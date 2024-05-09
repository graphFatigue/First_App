using TaskBoard.Domain.Entities;

namespace TaskBoard.Abstractions.Infrastructure
{
    public interface IBoardRepository: IGenericRepository<Board>
    {
        Task<Board?> GetByNameAsync(string name);
        Task<Board?> GetByIdAsync(int id);
    }
}
