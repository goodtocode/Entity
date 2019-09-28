
namespace GoodToCode.Entity.Hosting
{
    /// <summary>
    /// HttpSearchService contract
    /// </summary>
    public class HttpCrudOptions
    {
        /// <summary>
        /// Url of the query
        /// </summary>
        public string Type { get; set; } = default(string);

        /// <summary>
        /// Url of the query
        /// </summary>
        public string Url { get; set; } = default(string);
    }
}