using System.Collections.Generic;
using System.Threading.Tasks;
using CodeHollow.FeedReader;
using RSSFeedReader.Logic.Common.Models;

namespace RSSFeedReader.Logic.Services
{
    public class FeedHelper
    {
        public async Task<IEnumerable<NewsItemDto>> GetNewsByUrl(string url)
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
