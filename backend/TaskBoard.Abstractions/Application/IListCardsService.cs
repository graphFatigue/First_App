using Sieve.Models;
using TaskBoard.Common;
using TaskBoard.Common.Models.Card;
using TaskBoard.Common.Models.ListCards;

namespace TaskBoard.Abstractions.Application
{
    public interface IListCardsService
    {
        Task<IEnumerable<ListCardsModel>> GetAllAsync();
        Task<PagedList<ListCardsModel>> GetAllWithFilterAsync(SieveModel sieveModel);
        Task<ListCardsModel> GetByNameAsync(string name);
        Task<ListCardsModel> CreateAsync(CreateListCardsModel createListCardsModel);
        Task UpdateAsync(UpdateListCardsModel updateListCardsModel);
        Task<ListCardsModel> GetByIdAsync(int id);
        Task DeleteAsync(int id);
    }
}
