using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using RSSFeedReader.Logic.Common.Services;
using RSSFeedReader.Web.Models;

namespace RSSFeedReader.Web.Controllers
{
    /// <summary>
    /// Defines methods for choosing RSS channel and reading its news.
    /// </summary>
    /// <seealso cref="System.Web.Mvc.Controller" />
    public class HomeController : Controller
    {
        private const int PageSize = 10;
        private readonly INewsItemService newsItemService;
        private readonly IRssChannelService rssChannelService;

        /// <summary>
        /// Initializes a new instance of the <see cref="HomeController"/> class.
        /// </summary>
        /// <param name="newsItemService">The news item service.</param>
        /// <param name="rssChannelService">The RSS channel service.</param>
        public HomeController(INewsItemService newsItemService, IRssChannelService rssChannelService)
        {
            this.newsItemService = newsItemService;
            this.rssChannelService = rssChannelService;
        }

        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var channels = await this.rssChannelService.GetRssChannelsAsync();

            return View(channels);
        }

        [HttpGet]
        public async Task<ActionResult> News(int channelId, int page = 1)
        {
            var news = await this.newsItemService.GetNewsByRssChannelIdAsync(channelId).ConfigureAwait(false);

            var newsPerPage = news.Skip((page - 1) * PageSize).Take(PageSize);

            var pageInfo = new PageInfo { PageNumber = page, PageSize = PageSize, TotalItems = news.ToList().Count };

            var indexViewModel = new IndexViewModel { PageInfo = pageInfo, NewsItems = newsPerPage };

            return View(indexViewModel);            
        }
    }
}