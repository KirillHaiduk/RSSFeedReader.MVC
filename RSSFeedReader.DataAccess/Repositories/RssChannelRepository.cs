using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using RSSFeedReader.DataAccess.Common.Models;
using RSSFeedReader.DataAccess.Common.Repositories;
using RSSFeedReader.DataAccess.Context;

namespace RSSFeedReader.DataAccess.Repositories
{
    /// <summary>
    /// Provides methods for work with database entities of RSS channels.
    /// </summary>
    /// <seealso cref="RSSFeedReader.DataAccess.Repositories.BaseRepository{RSSFeedReader.DataAccess.Common.Models.RssChannelDbModel}" />
    /// <seealso cref="RSSFeedReader.DataAccess.Common.Repositories.IRssChannelRepository" />
    public class RssChannelRepository : BaseRepository<RssChannelDbModel>, IRssChannelRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RssChannelRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public RssChannelRepository(NewsContext context) : base(context)
        {
        }

        /// <inheritdoc/>
        public async Task<bool> IsValidRssChannel(string url)
        {
            return await dbSet.Where(c => c.Url == url).AnyAsync().ConfigureAwait(false);
        }
    }
}
