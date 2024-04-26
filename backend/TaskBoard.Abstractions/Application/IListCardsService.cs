using Sieve.Models;
using TaskBoard.Common.Models.Card;
using TaskBoard.Common;

namespace TaskBoard.Abstractions.Application
{
    public interface IListCardsService
    {
        Task<IEnumerable<CardModel>> GetAllAsync();
        Task<PagedList<CardModel>> GetAllWithFilterAsync(SieveModel sieveModel);
        Task<CardModel> GetByNameAsync(string name);
        Task<CardModel> CreateAsync(CreateCardModel createCardModel);
        Task UpdateAsync(int id, UpdateCardModel updateCardModel);
        Task DeleteAsync(int id);
    }
}
