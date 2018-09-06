using AutoMapper;
using RSSFeedReader.DataAccess.Common.Models;
using RSSFeedReader.Logic.Common.Models;

namespace RSSFeedReader.Logic.Mappings
{
    /// <summary>
    /// Represents mapping for news item models.
    /// </summary>
    /// <seealso cref="AutoMapper.Profile" />
    public class NewsItemMappingProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NewsItemMappingProfile"/> class.
        /// </summary>
        public NewsItemMappingProfile()
        {
            this.NewsItemDbModelMapping();
            this.NewsItemModelMapping();
        }

        private void NewsItemModelMapping()
        {
            CreateMap<NewsItemDbModel, NewsItemDto>()
                .ForMember(model => model.Id, opt => opt.MapFrom(dbModel => dbModel.Id))
                .ForMember(model => model.Title, opt => opt.MapFrom(dbModel => dbModel.Title))
                .ForMember(model => model.Description, opt => opt.MapFrom(dbModel => dbModel.Description))
                .ForMember(model => model.Url, opt => opt.MapFrom(dbModel => dbModel.Url))
                .ForMember(model => model.PublicationDate, opt => opt.MapFrom(dbModel => dbModel.PublicationDate))
                .ForMember(model => model.RssChannelId, opt => opt.MapFrom(dbModel => dbModel.RssChannelId))
                .ForAllOtherMembers(model => model.Ignore());
        }

        private void NewsItemDbModelMapping()
        {
            CreateMap<NewsItemDto, NewsItemDbModel>()
                .ForMember(dbModel => dbModel.Id, opt => opt.MapFrom(model => model.Id))
                .ForMember(dbModel => dbModel.Title, opt => opt.MapFrom(model => model.Title))
                .ForMember(dbModel => dbModel.Description, opt => opt.MapFrom(model => model.Description))
                .ForMember(dbModel => dbModel.Url, opt => opt.MapFrom(model => model.Url))
                .ForMember(dbModel => dbModel.PublicationDate, opt => opt.MapFrom(model => model.PublicationDate))
                .ForMember(dbModel => dbModel.RssChannelId, opt => opt.MapFrom(model => model.RssChannelId))
                .ForAllOtherMembers(model => model.Ignore());
        }
    }
}
