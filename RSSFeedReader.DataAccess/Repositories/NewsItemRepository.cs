using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using RSSFeedReader.DataAccess.Common.Models;
using RSSFeedReader.DataAccess.Common.Repositories;
using RSSFeedReader.DataAccess.Context;

namespace RSSFeedReader.DataAccess.Repositories
{
    /// <summary>
    /// Provides methods for work with database entities of News items.
    /// </summary>
    /// <seealso cref="RSSFeedReader.DataAccess.Repositories.BaseRepository{RSSFeedReader.DataAccess.Common.Models.NewsItemDbModel}" />
    /// <seealso cref="RSSFeedReader.DataAccess.Common.Repositories.INewsItemRepository" />
    public class NewsItemRepository : BaseRepository<NewsItemDbModel>, INewsItemRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NewsItemRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public NewsItemRepository(NewsContext context) : base(context)
        {
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<NewsItemDbModel>> GetNewsByDateAsync(DateTime date)
        {
            return await dbSet.Where(n => n.PublicationDate.HasValue && DbFunctions.TruncateTime(n.PublicationDate.Value) == DbFunctions.TruncateTime(date)).ToListAsync().ConfigureAwait(false);
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<NewsItemDbModel>> GetNewsByRssChannelIdAsync(int channelId)
        {
            return await dbSet.Where(n => n.RssChannelId == channelId).OrderBy(n => n.Id).ToListAsync().ConfigureAwait(false);
        }
    }
}
