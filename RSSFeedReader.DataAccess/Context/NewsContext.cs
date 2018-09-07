using System;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.SqlServer;
using System.IO;
using System.Reflection;
using RSSFeedReader.DataAccess.Common.Models;
using RSSFeedReader.DataAccess.Configurations;

namespace RSSFeedReader.DataAccess.Context
{
    /// <summary>
    /// Represents database context of news and RSS channels.
    /// </summary>
    /// <seealso cref="System.Data.Entity.DbContext" />
    [DbConfigurationType(typeof(NewsContextConfiguration))]
    public class NewsContext : DbContext
    {
        private const string ConnectionName = "RssReaderDb";
        private const string ConfigFileName = "RSSFeedReader.DataAccess.dll.config";
        private static readonly string ConnectionString;

        /// <summary>
        /// Initializes the <see cref="NewsContext"/> class.
        /// </summary>
        /// <exception cref="ConfigurationErrorsException"></exception>
        static NewsContext()
        {
            var codeBase = Assembly.GetExecutingAssembly().CodeBase;
            var uri = new UriBuilder(codeBase);
            string path = Uri.UnescapeDataString(uri.Path);
            string fullCfgFileName = $@"{Path.GetDirectoryName(path)}\{ConfigFileName}";

            var configMap = new ExeConfigurationFileMap() { ExeConfigFilename = fullCfgFileName };
            var config = ConfigurationManager.OpenMappedExeConfiguration(configMap, ConfigurationUserLevel.None);
            foreach (ConnectionStringSettings connectionString in config.ConnectionStrings.ConnectionStrings)
            {
                if (connectionString.Name.Equals(ConnectionName, StringComparison.OrdinalIgnoreCase))
                {
                    ConnectionString = connectionString.ConnectionString;
                    break;
                }
            }

            if (string.IsNullOrEmpty(ConnectionString))
            {
                throw new ConfigurationErrorsException($"Cannot find connection string with name {ConnectionName}");
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NewsContext"/> class.
        /// </summary>
        public NewsContext() : base(ConnectionString)
        {
        }

        /// <summary>
        /// Gets or sets the database news.
        /// </summary>
        /// <value>
        /// The database news.
        /// </value>
        public IDbSet<NewsItemDbModel> DbNews { get; set; }

        /// <summary>
        /// Gets or sets the database news channel.
        /// </summary>
        /// <value>
        /// The database news channel.
        /// </value>
        public IDbSet<RssChannelDbModel> DbNewsChannel { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new NewsItemDbModelConfig());
            modelBuilder.Configurations.Add(new RssChannelDbModelConfig());

            base.OnModelCreating(modelBuilder);
        }
    }

    /// <summary>
    /// Represents context configuration.
    /// </summary>
    /// <seealso cref="System.Data.Entity.DbConfiguration" />
    public class NewsContextConfiguration : DbConfiguration
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NewsContextConfiguration"/> class.
        /// </summary>
        public NewsContextConfiguration()
        {
            this.SetDefaultConnectionFactory(new LocalDbConnectionFactory("mssqllocaldb"));
            this.SetProviderServices(SqlProviderServices.ProviderInvariantName, SqlProviderServices.Instance);
        }
    }
}
