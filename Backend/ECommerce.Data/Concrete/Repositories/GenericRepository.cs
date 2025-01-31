using ECommerce.Data.Abstract;
using ECommerce.Data.Concrete.Context;
using ECommerce.Entity.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

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
        /// <summary>
        /// Adds a new entity to the database.
        /// </summary>
        /// <param name="entity">The entity to be added.</param>
        /// <returns>The added entity.</returns>
        public async Task<TEntity> AddAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
            return entity;
        }
        /// <summary>
        /// Adds a range of entities to the database.
        /// </summary>
        /// <param name="entities">The collection of entities to be added.</param>
        /// <returns>The collection of added entities.</returns>
        public async Task<IEnumerable<TEntity>> AddRangeAsync(IEnumerable<TEntity> entities)
        {
            if (entities == null || !entities.Any())
            throw new ArgumentNullException(nameof(entities));
            await _dbSet.AddRangeAsync(entities);
            return entities;
        }
        /// <summary>
        /// Checks if any entity in the database matches the given expression.
        /// </summary>
        /// <param name="anyExpression">The predicate expression to check.</param>
        /// <returns>True if any entity matches the expression, otherwise false.</returns>
        public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> anyExpression)
        {
            if (anyExpression == null)
                throw new ArgumentNullException(nameof(anyExpression));
            return await _dbSet.AnyAsync(anyExpression);
        }
        /// <summary>
        /// Returns the total count of entities in the database.
        /// </summary>
        /// <returns>The total number of entities.</returns>
        public async Task<int> CountAsync()
        {
            return await _dbSet.CountAsync();
        }
        /// <summary>
        /// Returns the count of entities that match the given predicate.
        /// </summary>
        /// <param name="predicate">The predicate expression to filter entities.</param>
        /// <returns>The number of entities that match the predicate.</returns>
        public async Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate)
        {
            if (predicate == null)
                throw new ArgumentNullException(nameof(predicate));
            return await _dbSet.CountAsync(predicate);
        }
        /// <summary>
        /// Finds an entity by the given predicate.
        /// </summary>
        /// <param name="predicate">The predicate expression to search for the entity.</param>
        /// <returns>The entity if found, otherwise null.</returns>
        public async Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> predicate)
        {
            if (predicate == null)
                throw new ArgumentNullException(nameof(predicate));
            return await _dbSet.FindAsync(predicate);
        }
        /// <summary>
        /// Returns all entities in the database without tracking them.
        /// </summary>
        /// <returns>A collection of all entities.</returns>
        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _dbSet.AsNoTracking().ToListAsync();
        }
        /// <summary>
        /// Returns a filtered, ordered, and/or limited collection of entities.
        /// </summary>
        /// <param name="predicate">The predicate expression to filter entities.</param>
        /// <param name="orderBy">The function to order entities.</param>
        /// <param name="take">The number of entities to return.</param>
        /// <param name="asNoTracking">If true, entities are returned without tracking.</param>
        /// <param name="includes">The functions for eager loading related entities.</param>
        /// <returns>A collection of entities based on the provided criteria.</returns>
        public async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>>? predicate = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null, int? take = null, bool asNoTracking = true, params Func<IQueryable<TEntity>, IQueryable<TEntity>>[] includes)
        {
            IQueryable<TEntity> query = _dbSet;
            //eager loading
            foreach (var include in includes)
            {
                query = include(query);
            }

            
            if (predicate != null)
            {
                query = query.Where(predicate);
            }

          
            if (orderBy != null)
            {
                query = orderBy(query);
            }

            if (take.HasValue)
            {
                query = query.Skip(0).Take(take.Value);
            }

          
            if (asNoTracking)
            {
                query = query.AsNoTracking();
            }
            return await query.ToListAsync();
        }
        /// <summary>
        /// Returns a single entity based on the given predicate and includes.
        /// </summary>
        /// <param name="predicate">The predicate expression to find the entity.</param>
        /// <param name="includes">The functions for eager loading related entities.</param>
        /// <returns>The entity if found, otherwise null.</returns>
        public Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate, params Func<IQueryable<TEntity>, IQueryable<TEntity>>[] includes)
        {
            IQueryable<TEntity> query = _dbSet;
            if(predicate != null)
            {
                query = query.Where(predicate);
            }
            if(includes != null) 
            {
            query=includes.Aggregate(query, (current, include) => include(current));
            }
            return query.FirstOrDefaultAsync();
        }
        /// <summary>
        /// Finds an entity by its identifier.
        /// </summary>
        /// <param name="id">The identifier of the entity.</param>
        /// <returns>The entity if found, otherwise null.</returns>
        public async  Task<TEntity> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }
        /// <summary>
        /// Permanently deletes an entity from the database.
        /// </summary>
        /// <param name="entity">The entity to be deleted.</param>
        public async Task HardDeleteAsync(Expression<Func<TEntity, bool>> predicate)
        {
            if (predicate == null)
                throw new ArgumentNullException(nameof(predicate));

        
            var entity = await _dbSet.FirstOrDefaultAsync(predicate);
            if (entity == null)
                throw new InvalidOperationException("Entity not found.");

            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }
        /// <summary>
        /// Marks an entity as deleted (soft delete) by setting the IsDeleted flag.
        /// </summary>
        /// <param name="entity">The entity to be marked as deleted.</param>
        public async void SoftDeleteAsync(TEntity entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            
            var baseEntity = entity as BaseEntity;
            if (baseEntity != null)
            {
                baseEntity.IsDeleted = true;  
               _dbSet.Update(entity);  
            
            }
        }
        /// <summary>
        /// Updates an existing entity in the database.
        /// </summary>
        /// <param name="entity">The entity to be updated.</param>
        public void UpdateAsync(TEntity entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            _dbSet.Update(entity);
        }

        public Task<IQueryable<TEntity>> QueryAsync()
        {
            return Task.FromResult(_dbSet.AsQueryable());
        }
    }
}
