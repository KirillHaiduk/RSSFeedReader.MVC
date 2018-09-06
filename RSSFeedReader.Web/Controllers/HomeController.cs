using RSSFeedReader.Logic.Common.Services;
using RSSFeedReader.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace RSSFeedReader.Web.Controllers
{
    public class HomeController : Controller
    {
        private const int PageSize = 10;
        private readonly INewsItemService newsItemService;
        private readonly IRssChannelService rssChannelService;

        public HomeController(INewsItemService newsItemService, IRssChannelService rssChannelService)
        {
            this.newsItemService = newsItemService;
            this.rssChannelService = rssChannelService;
        }

        public async Task<ActionResult> Index()
        {
            var channels = await this.rssChannelService.GetRssChannelsAsync();

            return View(channels);
        }

        public async Task<ActionResult> News(int channelId, int page = 1)
        {
            var news = await this.newsItemService.GetNewsByRssChannelIdAsync(channelId).ConfigureAwait(false);

            var newsPerPage = news.Skip((page - 1) * PageSize).Take(PageSize);

            var pageInfo=new PageInfo { PageNumber = page, PageSize = PageSize, TotalItems = news.ToList().Count };

            var indexViewModel = new IndexViewModel { PageInfo = pageInfo, NewsItems = newsPerPage };

            return View(indexViewModel);            
        }
    }
}