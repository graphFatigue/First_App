using Sieve.Models;
using TaskBoard.Common;
using TaskBoard.Common.Models.Board;

namespace TaskBoard.Abstractions.Application
{
    public interface IBoardService
    {
        Task<IEnumerable<BoardModel>> GetAllAsync();
        Task<PagedList<BoardModel>> GetAllWithFilterAsync(SieveModel sieveModel);
        Task<BoardModel> GetByNameAsync(string name);
        Task<BoardModel> CreateAsync(CreateBoardModel createBoardModel);
        Task UpdateAsync(UpdateBoardModel updateBoardModel);
        Task<BoardModel> GetByIdAsync(int id);
        Task DeleteAsync(int id);
    }
}
