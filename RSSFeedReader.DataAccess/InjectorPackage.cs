using SimpleInjector;
using SimpleInjector.Packaging;
using RSSFeedReader.DataAccess.Common.Repositories;
using RSSFeedReader.DataAccess.Repositories;

namespace RSSFeedReader.DataAccess
{
    public class InjectorPackage : IPackage
    {
        public void RegisterServices(Container container)
        {
            container.Register<INewsItemRepository, NewsItemRepository>();
            container.Register<IRssChannelRepository, RssChannelRepository>();
        }
    }
}
