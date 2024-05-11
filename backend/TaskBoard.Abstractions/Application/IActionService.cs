using Sieve.Models;
using TaskBoard.Common.Models.Card;
using TaskBoard.Common;
using TaskBoard.Common.Models.Action;

namespace TaskBoard.Abstractions.Application
{
    public interface IActionService
    {
        Task<IEnumerable<ActionModel>> GetAllAsync();
        Task<IEnumerable<ActionModel>> GetAllByCardIdAsync(int cardId);
        Task<PagedList<ActionModel>> GetAllWithFilterAsync(SieveModel sieveModel);
    }
}
