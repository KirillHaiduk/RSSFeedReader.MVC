using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using RSSFeedReader.DataAccess.Common.Models;

namespace RSSFeedReader.DataAccess.Common.Repositories
{
    /// <summary>
    /// Provides methods for work with database entities.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    /// <seealso cref="System.IDisposable" />
    public interface INewsRepository<TEntity> : IDisposable
        where TEntity : NewsEntity
    {
        /// <summary>
        /// Gets all entites asynchronous.
        /// </summary>
        /// <returns>Sequence of database entities.</returns>
        Task<IEnumerable<TEntity>> GetAllAsync();

        /// <summary>
        /// Gets entities by identifier asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Entity with given identifier.</returns>
        Task<TEntity> GetByIdAsync(int id);

        /// <summary>
        /// Adds entity to database asynchronous.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>Added entity.</returns>
        Task<TEntity> AddAsync(TEntity entity);

        /// <summary>
        /// Updates entity asynchronous.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>Updated entity.</returns>
        Task<TEntity> UpdateAsync(TEntity entity);

        /// <summary>
        /// Deletes entity asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        Task DeleteAsync(int id);

        /// <summary>
        /// Finds entities asynchronous.
        /// </summary>
        /// <param name="filterExpression">The filter expression.</param>
        /// <returns>Sequence of entities matching to filter.</returns>
        Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> filterExpression);

        /// <summary>
        /// Saves the changes asynchronous.
        /// </summary>
        /// <returns>A <see cref="Task"/> of deletion.</returns>
        Task SaveChangesAsync();
    }
}
