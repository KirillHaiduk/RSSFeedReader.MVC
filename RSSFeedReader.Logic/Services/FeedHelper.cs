using System.Collections.Generic;
using System.Threading.Tasks;
using CodeHollow.FeedReader;
using RSSFeedReader.Logic.Common.Models;
using RSSFeedReader.Logic.Common.Services;

namespace RSSFeedReader.Logic.Services
{
    /// <summary>
    /// Provides methods for reading and parsing news.
    /// </summary>
    /// <seealso cref="RSSFeedReader.Logic.Common.Services.IFeedHelper" />
    public class FeedHelper : IFeedHelper
    {
        /// <summary>
        /// Gets the news by URL.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <returns>Sequence of <see cref="NewsItemDto"/>.</returns>
        public async Task<IEnumerable<NewsItemDto>> GetNewsByUrlAsync(string url)
        {
            var feed = await FeedReader.ReadAsync(url).ConfigureAwait(false);

            var list = new List<NewsItemDto>();

            foreach (var item in feed.Items)
            {
                var newsItem = new NewsItemDto { Title = item.Title, Description = item.Description, PublicationDate = item.PublishingDate, Url = item.Link };
                list.Add(newsItem);
            }

            return list;
        }
    }
}
