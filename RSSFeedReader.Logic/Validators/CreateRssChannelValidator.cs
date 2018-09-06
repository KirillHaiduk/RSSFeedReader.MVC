using FluentValidation;
using RSSFeedReader.Logic.Common.Models;

namespace RSSFeedReader.Logic.Validators
{
    /// <summary>
    /// Represents validation for RSS channel.
    /// </summary>
    /// <seealso cref="FluentValidation.AbstractValidator{RSSFeedReader.Logic.Common.Models.RssChannelDto}" />
    public class CreateRssChannelValidator : AbstractValidator<RssChannelDto>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateRssChannelValidator"/> class.
        /// </summary>
        public CreateRssChannelValidator()
        {
            RuleFor(r => r.Url).NotEmpty().NotNull().Must(ValidationHelper.IsValidUrl);
            RuleFor(r => r.Title).NotEmpty().NotNull();
        }
    }
}
