using RSSFeedReader.Logic.Common.Services;
using RSSFeedReader.Logic.Services;
using SimpleInjector;
using SimpleInjector.Packaging;

namespace RSSFeedReader.Logic
{
    public class InjectorPackage : IPackage
    {
        public void RegisterServices(Container container)
        {
            container.Register<INewsItemService, NewsItemService>();
            container.Register<IRssChannelService, RssChannelService>();
        }
    }
}
