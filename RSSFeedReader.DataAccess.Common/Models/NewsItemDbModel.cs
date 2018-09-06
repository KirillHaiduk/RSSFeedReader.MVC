using System;

namespace RSSFeedReader.DataAccess.Common.Models
{
    /// <summary>
    /// Represents database entity of News item.
    /// </summary>
    /// <seealso cref="RSSFeedReader.DataAccess.Common.Models.NewsEntity" />
    public class NewsItemDbModel : NewsEntity
    {
        /// <summary>
        /// Gets or sets the publication date.
        /// </summary>
        public DateTime? PublicationDate { get; set; }               

        /// <summary>
        /// Gets or sets the RSS channel identifier.
        /// </summary>
        public int RssChannelId { get; set; }

        /// <summary>
        /// Gets or sets the RSS channel.
        /// </summary>
        public virtual RssChannelDbModel RssChannel { get; set; }
    }
}
