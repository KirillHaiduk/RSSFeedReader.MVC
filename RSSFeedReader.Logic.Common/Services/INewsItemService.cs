using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RSSFeedReader.Logic.Common.Models;

namespace RSSFeedReader.Logic.Common.Services
{
    /// <summary>
    /// Provides methods for work with News items.
    /// </summary>
    /// <seealso cref="System.IDisposable" />
    public interface INewsItemService : IDisposable
    {
        /// <summary>
        /// Gets the news item by identifier asynchronous.
        /// </summary>
        /// <param name="newsId">The news identifier.</param>
        /// <returns>News item with given identifier.</returns>
        Task<NewsItemDto> GetNewsItemAsync(int newsId);

        /// <summary>
        /// Gets the news items asynchronous.
        /// </summary>
        /// <returns>Sequence of news items.</returns>
        Task<IEnumerable<NewsItemDto>> GetNewsItemsAsync();

        /// <summary>
        /// Gets the news by RSS channel identifier asynchronous.
        /// </summary>
        /// <param name="channelId">The channel identifier.</param>
        /// <returns>Sequence of news items with given channel identifier.</returns>
        Task<IEnumerable<NewsItemDto>> GetNewsByRssChannelIdAsync(int channelId);

        /// <summary>
        /// Gets the news by date asynchronous.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns>Sequence of news items with given date.</returns>
        Task<IEnumerable<NewsItemDto>> GetNewsByDateAsync(DateTime date);

        /// <summary>
        /// Deletes the news item by identifier asynchronous.
        /// </summary>
        /// <param name="itemId">The item identifier.</param>
        /// <returns>A <see cref="Task"/> of deletion.</returns>
        Task DeleteNewsItemAsync(int itemId);
    }
}
