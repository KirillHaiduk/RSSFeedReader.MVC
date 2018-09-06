using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using RSSFeedReader.DataAccess.Common.Models;
using RSSFeedReader.DataAccess.Common.Repositories;
using RSSFeedReader.Logic.Common.Models;
using RSSFeedReader.Logic.Common.Services;

namespace RSSFeedReader.Logic.Services
{
    /// <summary>
    /// Provides methods for work with RSS channels.
    /// </summary>
    /// <seealso cref="RSSFeedReader.Logic.Common.Services.IRssChannelService" />
    public class RssChannelService : IRssChannelService
    {
        private readonly IRssChannelRepository rssChannelRepository;
        private readonly IMapper mapper;
        private bool disposed = false;

        /// <summary>
        /// Initializes a new instance of the <see cref="RssChannelService"/> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="mapper">The mapper.</param>
        public RssChannelService(IRssChannelRepository repository, IMapper mapper)
        {
            this.rssChannelRepository = repository;
            this.mapper = mapper;
        }

        /// <inheritdoc/>
        public async Task CreateRssChannelAsync(string url)
        {
            if (await this.rssChannelRepository.IsValidRssChannel(url))
            {
                throw new ArgumentException($"Channel {url} already exist.");
            }

            var rssChannel = new RssChannelDto() { Url = url };
            await this.rssChannelRepository.AddAsync(mapper.Map<RssChannelDbModel>(rssChannel)).ConfigureAwait(false);
        }

        /// <inheritdoc/>
        public async Task DeleteRssChannelAsync(int rssChannelId)
        {
            await this.rssChannelRepository.DeleteAsync(rssChannelId).ConfigureAwait(false);
        }

        /// <inheritdoc/>
        public async Task<RssChannelDto> GetRssChannelAsync(int rssChannelId)
        {
            var rssChannel = await this.rssChannelRepository.GetByIdAsync(rssChannelId).ConfigureAwait(false);

            return this.mapper.Map<RssChannelDto>(rssChannel);
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<RssChannelDto>> GetRssChannelsAsync()
        {
            var list = new List<RssChannelDto>();

            var channels = await this.rssChannelRepository.GetAllAsync().ConfigureAwait(false);

            foreach (var channel in channels)
            {
                list.Add(this.mapper.Map<RssChannelDto>(channel));
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
                    rssChannelRepository?.Dispose();
                }
                
                disposed = true;
            }
        }        
    }
}
