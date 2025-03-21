﻿using ECommerce.Entity.Abstract;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Data.Abstract
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        
        Task<TEntity> AddAsync(TEntity entity);

        Task<IEnumerable<TEntity>> AddRangeAsync(IEnumerable<TEntity> entities);

        Task HardDeleteAsync(Expression<Func<TEntity, bool>> predicate);

        void SoftDeleteAsync(TEntity entity);

        void UpdateAsync(TEntity entity);
        Task<TEntity> GetAsync(
            Expression<Func<TEntity, bool>> predicate,
            params Func<IQueryable<TEntity>, IQueryable<TEntity>>[] includes
            );

        Task<IEnumerable<TEntity>> GetAllAsync();

        Task<IEnumerable<TEntity>> GetAllAsync(
            Expression<Func<TEntity, bool>>? predicate = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
            int? take = null,
             bool asNoTracking = false,
            params Func<IQueryable<TEntity>, IQueryable<TEntity>>[] includes
            );

        Task<TEntity> GetByIdAsync(int id);

        Task<bool> AnyAsync(Expression<Func<TEntity, bool>> anyExpression);

        Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> predicate);
        Task<int> CountAsync();
        Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate);

        public Task<IQueryable<TEntity>> QueryAsync();
    }
}
