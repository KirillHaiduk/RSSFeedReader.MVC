using AutoMapper;
using RSSFeedReader.DataAccess.Common.Models;
using RSSFeedReader.Logic.Common.Models;

namespace RSSFeedReader.Logic.Mappings
{
    /// <summary>
    /// Represents mapping for RSS channel models.
    /// </summary>
    /// <seealso cref="AutoMapper.Profile" />
    public class RssChannelMappingProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RssChannelMappingProfile"/> class.
        /// </summary>
        public RssChannelMappingProfile()
        {
            this.RssChannelDbModelMapping();
            this.RssChannelModelMapping();
        }

        private void RssChannelModelMapping()
        {
            CreateMap<RssChannelDbModel, RssChannelDto>()
                .ForMember(model => model.Id, opt => opt.MapFrom(dbModel => dbModel.Id))
                .ForMember(model => model.Title, opt => opt.MapFrom(dbModel => dbModel.Title))
                .ForMember(model => model.Url, opt => opt.MapFrom(dbModel => dbModel.Url))
                .ForMember(model => model.Description, opt => opt.MapFrom(dbModel => dbModel.Description))
                .ForAllOtherMembers(model => model.Ignore());
        }

        private void RssChannelDbModelMapping()
        {
            CreateMap<RssChannelDto, RssChannelDbModel>()
                .ForMember(dbModel => dbModel.Id, opt => opt.MapFrom(model => model.Id))
                .ForMember(dbModel => dbModel.Title, opt => opt.MapFrom(model => model.Title))
                .ForMember(dbModel => dbModel.Url, opt => opt.MapFrom(model => model.Url))
                .ForMember(dbModel => dbModel.Description, opt => opt.MapFrom(model => model.Description))
                .ForAllOtherMembers(dbModel => dbModel.Ignore());
        }
    }
}
