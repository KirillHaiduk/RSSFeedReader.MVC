using System;

namespace RSSFeedReader.Logic.Validators
{
    /// <summary>
    /// Provides validation for URLs.
    /// </summary>
    public static class ValidationHelper
    {
        /// <summary>
        /// Determines whether given URL is valid.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <returns>
        ///   <c>true</c> if is valid URL; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsValidUrl(string url)
        {
            if (string.IsNullOrEmpty(url))
            {
                return false;
            }

            return Uri.TryCreate(url, UriKind.Absolute, out Uri result)
                && (result.Scheme == Uri.UriSchemeHttp || result.Scheme == Uri.UriSchemeHttps);
        }
    }
}
