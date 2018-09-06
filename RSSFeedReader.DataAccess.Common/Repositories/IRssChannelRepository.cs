using System.Threading.Tasks;
using RSSFeedReader.DataAccess.Common.Models;

namespace RSSFeedReader.DataAccess.Common.Repositories
{
    /// <summary>
    /// Provides methods for work with database entities of RSS channels.
    /// </summary>
    /// <seealso cref="RSSFeedReader.DataAccess.Common.Repositories.INewsRepository{RSSFeedReader.DataAccess.Common.Models.RssChannelDbModel}" />
    public interface IRssChannelRepository : INewsRepository<RssChannelDbModel>
    {
        /// <summary>
        /// Determines whether RSS channel is valid by the specified URL.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <returns>True if channel is valid; otherwise, false.</returns>
        Task<bool> IsValidRssChannel(string url);
    }
}
