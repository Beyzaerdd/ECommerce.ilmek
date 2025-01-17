using ECommerce.Data.Abstract;
using ECommerce.Data.Concrete.Context;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Data.Concrete
{    /// <summary>
     /// UnitOfWork class provides a way to manage database transactions and repositories.
     /// It implements the IUnitOfWork interface to ensure consistency.
     /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ECommerceDbContext _context;
        private readonly IServiceProvider _serviceProvider;
        public UnitOfWork(ECommerceDbContext context, IServiceProvider serviceProvider = null)
        {
            _context = context;
            _serviceProvider = serviceProvider;
        }

        /// <summary>
        /// Disposes of the DbContext to release resources.
        /// </summary>
        public void Dispose()
        {
            _context.Dispose();
        }
        /// <summary>
        /// Retrieves a generic repository for a specific entity type.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <returns>An instance of a generic repository for the specified entity.</returns>

        public IGenericRepository<TEntity> GetRepository<TEntity>() where TEntity : class
        {
            return _serviceProvider.GetRequiredService<IGenericRepository<TEntity>>();
        }
        /// <summary>
        /// Saves all changes made in the context to the database asynchronously.
        /// </summary>
        /// <returns>The number of state entries written to the database.</returns>
        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
