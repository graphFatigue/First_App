using Sieve.Models;
using TaskBoard.Common.Models.Card;
using TaskBoard.Common;

namespace TaskBoard.Abstractions.Application
{
    public interface IActionService
    {
        Task<IEnumerable<CardModel>> GetAllAsync();
        Task<PagedList<CardModel>> GetAllWithFilterAsync(SieveModel sieveModel);
        //Task<CardModel> GetByIdAsync(int id);
        //Task<CardModel> CreateAsync(CreateCardModel createCardModel);
        //Task DeleteAsync(int id);
    }
}
