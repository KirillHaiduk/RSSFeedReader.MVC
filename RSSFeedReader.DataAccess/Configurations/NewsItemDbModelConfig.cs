using System.Data.Entity.ModelConfiguration;
using RSSFeedReader.DataAccess.Common.Models;

namespace RSSFeedReader.DataAccess.Configurations
{
    /// <summary>
    /// Provides configuration for database entity of News item.
    /// </summary>
    /// <seealso cref="System.Data.Entity.ModelConfiguration.EntityTypeConfiguration{RSSFeedReader.DataAccess.Common.Models.NewsItemDbModel}" />
    internal sealed class NewsItemDbModelConfig : EntityTypeConfiguration<NewsItemDbModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NewsItemDbModelConfig"/> class.
        /// </summary>
        public NewsItemDbModelConfig()
        {
            ToTable("news_items");
            HasKey(n => n.Id);
            HasRequired(n => n.RssChannel).WithMany(r => r.News).HasForeignKey(n => n.RssChannelId).WillCascadeOnDelete();
            Property(n => n.Id).HasColumnName("news_item_id");
            Property(n => n.Title).HasColumnName("news_item_title").IsRequired();
            Property(n => n.Url).HasColumnName("news_item_url").IsRequired();
            Property(n => n.Description).HasColumnName("news_item_description").IsOptional();
            Property(n => n.PublicationDate).HasColumnName("news_item_publication_date").IsOptional();
        }
    }
}
