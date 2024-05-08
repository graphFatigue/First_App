using Action = TaskBoard.Domain.Entities.Action;

namespace TaskBoard.Abstractions.Infrastructure
{
    public interface IActionRepository: IGenericRepository<Action>
    {
        Task<Action?> GetByIdAsync(int id);
        Task<IEnumerable<Action>>  GetAllByCardIdAsync(int cardId);
    }
}
