using System.Collections.Generic;

namespace RSSFeedReader.DataAccess.Common.Models
{
    /// <summary>
    /// Represents database entity of RSS channel.
    /// </summary>
    /// <seealso cref="RSSFeedReader.DataAccess.Common.Models.NewsEntity" />
    public class RssChannelDbModel : NewsEntity
    {           
        /// <summary>
        /// Gets or sets the news list.
        /// </summary>
        public ICollection<NewsItemDbModel> News { get; set; }
    }
}
