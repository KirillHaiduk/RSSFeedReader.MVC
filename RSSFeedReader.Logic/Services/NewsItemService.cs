using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using RSSFeedReader.DataAccess.Common.Repositories;
using RSSFeedReader.Logic.Common.Models;
using RSSFeedReader.Logic.Common.Services;

namespace RSSFeedReader.Logic.Services
{
    /// <summary>
    /// Provides methods for work with News items.
    /// </summary>
    /// <seealso cref="RSSFeedReader.Logic.Common.Services.INewsItemService" />
    public class NewsItemService : INewsItemService
    {
        private readonly INewsItemRepository newsItemRepository;
        private readonly IMapper mapper;
        private readonly IRssChannelService rssChannelService;
        private readonly FeedHelper feedHelper;
        private bool disposed = false;

        /// <summary>
        /// Initializes a new instance of the <see cref="NewsItemService"/> class.
        /// </summary>
        /// <param name="newsItemRepository">The news item repository.</param>
        /// <param name="mapper">The mapper.</param>
        /// <param name="rssChannelService">The RSS channel service.</param>
        /// <exception cref="ArgumentNullException"> Thrown when
        /// newsItemRepository
        /// or
        /// mapper
        /// or
        /// rssChannelService is null.
        /// </exception>
        public NewsItemService(INewsItemRepository newsItemRepository, IMapper mapper, IRssChannelService rssChannelService)
        {
            this.newsItemRepository = newsItemRepository ?? throw new ArgumentNullException(nameof(newsItemRepository));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            this.rssChannelService = rssChannelService ?? throw new ArgumentNullException(nameof(rssChannelService));
            this.feedHelper = new FeedHelper();
        }

        /// <inheritdoc/>
        public async Task DeleteNewsItemAsync(int itemId)
        {
            await newsItemRepository.DeleteAsync(itemId).ConfigureAwait(false);
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<NewsItemDto>> GetNewsByDateAsync(DateTime date)
        {
            var list = new List<NewsItemDto>();

            var news = await newsItemRepository.GetNewsByDateAsync(date);

            foreach (var item in news)
            {
                list.Add(mapper.Map<NewsItemDto>(item));
            }

            return list;
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<NewsItemDto>> GetNewsByRssChannelIdAsync(int channelId)
        {
            //var list = new List<NewsItemDto>();

            var channel = await this.rssChannelService.GetRssChannelAsync(channelId).ConfigureAwait(false);

            var news = await this.feedHelper.GetNewsByUrl(channel.Url).ConfigureAwait(false);

            //foreach (var item in news)
            //{
            //    //list.Add(mapper.Map<NewsItemDto>(item));
            //    list.Add(item);
            //}

            //return list;
            return news;
        }

        /// <inheritdoc/>
        public async Task<NewsItemDto> GetNewsItemAsync(int newsId)
        {
            var item = await newsItemRepository.GetByIdAsync(newsId).ConfigureAwait(false);

            return mapper.Map<NewsItemDto>(item);
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<NewsItemDto>> GetNewsItemsAsync()
        {
            var list = new List<NewsItemDto>();

            var news = await newsItemRepository.GetAllAsync();

            foreach (var item in news)
            {
                list.Add(mapper.Map<NewsItemDto>(item));
            }

            return list;
        }         

        /// <inheritdoc/>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    newsItemRepository?.Dispose();
                }

                disposed = true;
            }
        }
    }
}
