using System.Collections.Generic;
using RSSFeedReader.Logic.Common.Models;

namespace RSSFeedReader.Web.Models
{
    /// <summary>
    /// Represents information that is tranfered to view.
    /// </summary>
    public class IndexViewModel
    {
        /// <summary>
        /// Gets or sets the news items.
        /// </summary>
        /// <value>
        /// The news items.
        /// </value>
        public IEnumerable<NewsItemDto> NewsItems { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="PageInfo"/>.
        /// </summary>
        /// <value>
        /// The page information.
        /// </value>
        public PageInfo PageInfo { get; set; }
    }
}