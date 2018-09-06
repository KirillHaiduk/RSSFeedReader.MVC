using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RSSFeedReader.DataAccess.Common.Models;

namespace RSSFeedReader.DataAccess.Common.Repositories
{
    /// <summary>
    /// Provides methods for work with database entities of News items.
    /// </summary>
    /// <seealso cref="RSSFeedReader.DataAccess.Common.Repositories.INewsRepository{RSSFeedReader.DataAccess.Common.Models.NewsItemDbModel}" />
    public interface INewsItemRepository : INewsRepository<NewsItemDbModel>
    {
        /// <summary>
        /// Gets the news by RSS channel identifier asynchronous.
        /// </summary>
        /// <param name="channelId">The channel identifier.</param>
        /// <returns>Sequence of news from given RSS channel.</returns>
        Task<IEnumerable<NewsItemDbModel>> GetNewsByRssChannelIdAsync(int channelId);

        /// <summary>
        /// Gets the news by date asynchronous.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns>Sequence of news from given date.</returns>
        Task<IEnumerable<NewsItemDbModel>> GetNewsByDateAsync(DateTime date);
    }
}
