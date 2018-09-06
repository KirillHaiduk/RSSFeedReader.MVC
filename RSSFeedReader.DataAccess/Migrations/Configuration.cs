using System.Data.Entity.Migrations;
using RSSFeedReader.DataAccess.Common.Models;
using RSSFeedReader.DataAccess.Context;

namespace RSSFeedReader.DataAccess.Migrations
{
    /// <summary>
    /// Provides configuration of database migration.
    /// </summary>
    /// <seealso cref="System.Data.Entity.Migrations.DbMigrationsConfiguration{RSSFeedReader.DataAccess.Context.NewsContext}" />
    internal sealed class Configuration : DbMigrationsConfiguration<NewsContext>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Configuration"/> class.
        /// </summary>
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations\NewsContext";
            ContextKey = "RSSFeedReader.DataAccess.Context.NewsContext";
        }

        protected override void Seed(NewsContext context)
        {
            context.DbNewsChannel.AddOrUpdate(
                c => c.Id,
                new RssChannelDbModel { Url = "http://www.interfax.by/news/feed", Title = "Interfax", Description = "News form Interfax" },
                new RssChannelDbModel { Url = "http://habrahabr.ru/rss/", Title = "Habrahabr", Description = "News from Habrahabr" }
                );

            context.SaveChanges();
        }
    }
}
