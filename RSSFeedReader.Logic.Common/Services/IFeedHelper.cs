using System.Collections.Generic;
using System.Threading.Tasks;
using RSSFeedReader.Logic.Common.Models;

namespace RSSFeedReader.Logic.Common.Services
{
    /// <summary>
    /// Provides methods for reading and parsing news.
    /// </summary>
    public interface IFeedHelper
    {
        /// <summary>
        /// Gets the news by URL.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <returns></returns>
        Task<IEnumerable<NewsItemDto>> GetNewsByUrlAsync(string url);
    }
}
