using Sieve.Models;
using TaskBoard.Common;
using TaskBoard.Common.Models.Card;

namespace TaskBoard.Abstractions.Application
{
    public interface ICardService
    {
        Task<IEnumerable<CardModel>> GetAllAsync();
        Task<IEnumerable<CardModel>> GetAllWithoutParentListAsync();
        Task<PagedList<CardModel>> GetAllWithFilterAsync(SieveModel sieveModel);
        Task<CardModel> GetByIdAsync(int id);
        Task<CardModel> CreateAsync(CreateCardModel createCardModel);
        Task UpdateAsync(UpdateCardModel updateCardModel);
        Task DeleteAsync(int id);
    }
}
