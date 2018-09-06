using System;

namespace RSSFeedReader.Logic.Common.Models
{
    /// <summary>
    /// Represents the entity of news item.
    /// </summary>
    public class NewsItemDto
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the link.
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the publication date.
        /// </summary>
        public DateTime? PublicationDate { get; set; }

        /// <summary>
        /// Gets or sets the RSS channel identifier.
        /// </summary>
        public int RssChannelId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether news item was read.
        /// </summary>
        /// <value>
        ///   <c>true</c> if was read; otherwise, <c>false</c>.
        /// </value>
        public bool WasRead { get; set; }
    }
}