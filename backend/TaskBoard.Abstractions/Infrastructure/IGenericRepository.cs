using Sieve.Models;
using TaskBoard.Common;

namespace TaskBoard.Abstractions.Infrastructure
{
    public interface IGenericRepository<TEntity>
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<PagedList<TEntity>> GetAllWithFilterAsync(SieveModel sieveModel);
        Task CreateAsync(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
}
