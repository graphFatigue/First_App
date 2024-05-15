using Microsoft.EntityFrameworkCore;
using Sieve.Models;
using Sieve.Services;
using TaskBoard.Abstractions.Infrastructure;
using TaskBoard.Common;

namespace TaskBoard.Infrastructure.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        protected readonly AppDbContext _context;
        protected readonly DbSet<TEntity> _dbSet;
        private readonly ISieveProcessor _sieveProcessor;

        protected GenericRepository(
            AppDbContext context,
            ISieveProcessor sieveProcessor)
        {
            _context = context;
            _sieveProcessor = sieveProcessor;
            _dbSet = context.Set<TEntity>();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<PagedList<TEntity>> GetAllWithFilterAsync(SieveModel sieveModel)
        {
            var entities = _sieveProcessor
                .Apply(sieveModel, _dbSet.AsQueryable(), applyPagination: false);

            return await PagedList<TEntity>.ToPagedListAsync(entities, sieveModel);
        }

        public async Task CreateAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public void Update(TEntity entity)
        {
            _dbSet.Update(entity);
        }

        public void Delete(TEntity entity)
        {
            _dbSet.Remove(entity);
        }
    }
}
