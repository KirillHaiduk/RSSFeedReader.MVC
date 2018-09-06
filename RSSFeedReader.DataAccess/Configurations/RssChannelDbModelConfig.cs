using System.Data.Entity.ModelConfiguration;
using RSSFeedReader.DataAccess.Common.Models;

namespace RSSFeedReader.DataAccess.Configurations
{
    /// <summary>
    /// Provides configuration for database entity of RSS channel.
    /// </summary>
    /// <seealso cref="System.Data.Entity.ModelConfiguration.EntityTypeConfiguration{RSSFeedReader.DataAccess.Common.Models.RssChannelDbModel}" />
    internal sealed class RssChannelDbModelConfig : EntityTypeConfiguration<RssChannelDbModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RssChannelDbModelConfig"/> class.
        /// </summary>
        public RssChannelDbModelConfig()
        {
            ToTable("rss_channels");
            HasKey(r => r.Id);
            Property(r => r.Id).HasColumnName("rss_channel_id");
            Property(r => r.Title).HasColumnName("rss_channel_title").IsRequired();
            Property(r => r.Url).HasColumnName("rss_channel_url").IsRequired();
            Property(r => r.Description).HasColumnName("rss_channel_description").IsOptional();
        }
    }
}
