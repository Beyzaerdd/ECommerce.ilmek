using ECommerce.Data.Abstract;
using ECommerce.Data.Concrete.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Data.Concrete.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly ECommerceDbContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public GenericRepository(ECommerceDbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
            return entity;
        }

        public async Task<IEnumerable<TEntity>> AddRangeAsync(IEnumerable<TEntity> entities)
        {
            if (entities == null || !entities.Any())
            throw new ArgumentNullException(nameof(entities), "Entities cannot be null or empty.");
            await _dbSet.AddRangeAsync(entities);
            return entities;
        }

        public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> anyExpression)
        {
            if (anyExpression == null)
                throw new ArgumentNullException(nameof(anyExpression));
            return await _dbSet.AnyAsync(anyExpression);
        }

        public async Task<int> CountAsync()
        {
            return await _dbSet.CountAsync();
        }

        public async Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate)
        {
            if (predicate == null)
                throw new ArgumentNullException(nameof(predicate));
            return await _dbSet.CountAsync(predicate);
        }

        public async Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> predicate)
        {
            if (predicate == null)
                throw new ArgumentNullException(nameof(predicate));
            return await _dbSet.FindAsync(predicate);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _dbSet.AsNoTracking().ToListAsync();
        }

        public Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>>? predicate = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null, int? take = null, bool asNoTracking = false, params Func<IQueryable<TEntity>, IQueryable<TEntity>>[] includes)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate, params Func<IQueryable<TEntity>, IQueryable<TEntity>>[] includes)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> GetByIdAsync(object id)
        {
            throw new NotImplementedException();
        }

        public void HardDeleteAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void SoftDeleteAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void UpdateAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
