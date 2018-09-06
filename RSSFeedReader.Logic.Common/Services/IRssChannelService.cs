using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RSSFeedReader.Logic.Common.Models;

namespace RSSFeedReader.Logic.Common.Services
{
    /// <summary>
    /// Provides methods for work with RSS channels.
    /// </summary>
    /// <seealso cref="System.IDisposable" />
    public interface IRssChannelService : IDisposable
    {
        /// <summary>
        /// Creates the RSS channel asynchronous.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <returns>Created channel.</returns>
        Task CreateRssChannelAsync(string url);

        /// <summary>
        /// Gets the RSS channel by identifier asynchronous.
        /// </summary>
        /// <param name="rssChannelId">The RSS channel identifier.</param>
        /// <returns>RSS channel with given identifier.</returns>
        Task<RssChannelDto> GetRssChannelAsync(int rssChannelId);

        /// <summary>
        /// Gets the RSS channels asynchronous.
        /// </summary>
        /// <returns>Sequence of RSS channels.</returns>
        Task<IEnumerable<RssChannelDto>> GetRssChannelsAsync();

        /// <summary>
        /// Deletes the RSS channel by identifier asynchronous.
        /// </summary>
        /// <param name="rssChannelId">The RSS channel identifier.</param>
        /// <returns>A <see cref="Task"/> of deletion.</returns>
        Task DeleteRssChannelAsync(int rssChannelId);
    }
}
