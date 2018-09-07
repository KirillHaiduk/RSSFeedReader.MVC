using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using RSSFeedReader.Logic.Common.Services;
using SimpleInjector;
using SimpleInjector.Lifestyles;

namespace RSSFeedReader.Console
{
    public class Program
    {
        private static readonly Container container;

        static Program()
        {
            container = new Container();

            container.Options.DefaultLifestyle = new AsyncScopedLifestyle();

            container.RegisterPackages(GetAssemblies());

            container.Verify(VerificationOption.VerifyOnly);
        }

        public static void Main(string[] args)
        {
            Task.WaitAll(ReadNews());
        }

        private static async Task ReadNews()
        {            
            var provider = new NewsProvider(
                container.GetInstance<IRssChannelService>(),
                container.GetInstance<INewsItemService>(),
                container.GetInstance<IFeedHelper>());

            var news = await provider.GetAllNewsAsync().ConfigureAwait(false);

            foreach (var item in news)
            {
                System.Console.WriteLine($"ID: {item.Id}, Title: {item.Title}, Description: {item.Description}, Published: {item.PublicationDate}");
            }
        }

        private static Assembly[] GetAssemblies()
        {
            return AppDomain.CurrentDomain.GetAssemblies().Where(asm =>
                asm.FullName.StartsWith("RSSFeedReader", StringComparison.OrdinalIgnoreCase)).ToArray();
        }
    }
}
