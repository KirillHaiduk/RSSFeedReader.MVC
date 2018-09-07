using System.Collections.Generic;
using System.Threading.Tasks;
using RSSFeedReader.Logic.Common.Models;
using RSSFeedReader.Logic.Common.Services;

namespace RSSFeedReader.Console
{
    public class NewsProvider
    {
        private readonly IRssChannelService rssChannelService;
        private readonly INewsItemService newsItemService;
        private readonly IFeedHelper feedHelper;

        public NewsProvider(IRssChannelService rssChannelService, INewsItemService newsItemService, IFeedHelper feedHelper)
        {
            this.rssChannelService = rssChannelService;
            this.newsItemService = newsItemService;
            this.feedHelper = feedHelper;
        }

        public async Task<IEnumerable<NewsItemDto>> GetAllNewsAsync()
        {
            var news = new List<NewsItemDto>();

            var channels = await this.GetRssChannelsAsync();

            foreach (var channel in channels)
            {
                news.AddRange(await this.feedHelper.GetNewsByUrlAsync(channel.Url));
            }

            return news;
        }

        private async Task<IEnumerable<RssChannelDto>> GetRssChannelsAsync()
        {
            return await this.rssChannelService.GetRssChannelsAsync().ConfigureAwait(false);
        }
    }
}
