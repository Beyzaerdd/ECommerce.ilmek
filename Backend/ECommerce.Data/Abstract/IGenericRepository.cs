using ECommerce.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Data.Abstract
{
    public interface IGenericRepository<T, TPrimaryKey> where T : BaseEntity<TPrimaryKey>
    {
       
        Task<TEntity> AddAsync<TEntity, TPrimaryKey>(TEntity entity)
       where TEntity : BaseEntity<TPrimaryKey>;

        Task<IEnumerable<TEntity>> AddRangeAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : class;

    }
}
