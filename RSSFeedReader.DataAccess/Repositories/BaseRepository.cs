using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using RSSFeedReader.DataAccess.Common.Models;
using RSSFeedReader.DataAccess.Common.Repositories;
using RSSFeedReader.DataAccess.Context;

namespace RSSFeedReader.DataAccess.Repositories
{
    /// <summary>
    /// Provides methods for work with database entities.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    /// <seealso cref="RSSFeedReader.DataAccess.Common.Repositories.INewsRepository{TEntity}" />
    public class BaseRepository<TEntity> : INewsRepository<TEntity>
        where TEntity : NewsEntity
    {
        protected readonly NewsContext context;
        protected readonly DbSet<TEntity> dbSet;
        private bool disposed = false;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseRepository{TEntity}"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <exception cref="ArgumentNullException">context</exception>
        public BaseRepository(NewsContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
            this.dbSet = this.context.Set<TEntity>();
        }

        /// <inheritdoc/>
        public virtual async Task<TEntity> AddAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            var result = this.dbSet.Add(entity);
            await SaveChangesAsync();
            return result;
        }

        /// <inheritdoc/>
        public virtual async Task DeleteAsync(int id)
        {
            if (id < 1)
            {
                throw new ArgumentOutOfRangeException($"Identifier {nameof(id)} must be greater than 1");
            }

            var entityToDelete = await this.dbSet.FindAsync(id).ConfigureAwait(false);

            if (entityToDelete != null)
            {
                this.dbSet.Remove(entityToDelete);
            }

            await SaveChangesAsync();
        }

        /// <inheritdoc/>
        public virtual async Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> filterExpression)
        {
            if (filterExpression == null)
            {
                throw new ArgumentNullException(nameof(filterExpression));
            }

            return await this.dbSet.Where(filterExpression).ToListAsync().ConfigureAwait(false);
        }

        /// <inheritdoc/>
        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await this.dbSet.ToListAsync().ConfigureAwait(false);
        }

        /// <inheritdoc/>
        public virtual async Task<TEntity> GetByIdAsync(int id)
        {
            if (id < 1)
            {
                throw new ArgumentOutOfRangeException($"Identifier {nameof(id)} must be greater than 1");
            }

            return await this.dbSet.AsNoTracking().SingleOrDefaultAsync(t => t.Id == id).ConfigureAwait(false);
        }

        /// <inheritdoc/>
        public virtual async Task<TEntity> UpdateAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            this.context.Entry(entity).State = EntityState.Modified;

            await this.context.SaveChangesAsync();

            var result = await GetByIdAsync(entity.Id);

            return result;
        }

        /// <inheritdoc/>
        public async Task SaveChangesAsync()
        {
            await context.SaveChangesAsync().ConfigureAwait(false);
        }

        /// <inheritdoc />
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    this.context?.Dispose();
                }
            }

            disposed = true;
        }        
    }
}
