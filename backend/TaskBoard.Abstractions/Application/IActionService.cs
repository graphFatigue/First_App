using Sieve.Models;
using TaskBoard.Common.Models.Card;
using TaskBoard.Common;
using TaskBoard.Common.Models.Action;

namespace TaskBoard.Abstractions.Application
{
    public interface IActionService
    {
        Task<IEnumerable<ActionModel>> GetAllAsync();
        Task<PagedList<ActionModel>> GetAllWithFilterAsync(SieveModel sieveModel);
        //Task<CardModel> GetByIdAsync(int id);
        //Task<CardModel> CreateAsync(CreateCardModel createCardModel);
        //Task DeleteAsync(int id);
    }
}
