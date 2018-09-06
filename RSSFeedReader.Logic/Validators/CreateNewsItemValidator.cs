using FluentValidation;
using RSSFeedReader.Logic.Common.Models;

namespace RSSFeedReader.Logic.Validators
{
    /// <summary>
    /// Represents validation for News item.
    /// </summary>
    /// <seealso cref="FluentValidation.AbstractValidator{RSSFeedReader.Logic.Common.Models.NewsItemDto}" />
    public class CreateNewsItemValidator : AbstractValidator<NewsItemDto>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateNewsItemValidator"/> class.
        /// </summary>
        public CreateNewsItemValidator()
        {
            RuleFor(c => c.Url).NotEmpty().NotNull().Must(ValidationHelper.IsValidUrl);
            RuleFor(c => c.Title).NotEmpty().NotNull();
            RuleFor(c => c.RssChannelId).NotEmpty().NotNull();            
        }
    }
}
