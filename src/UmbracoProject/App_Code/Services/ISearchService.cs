using Umbraco.Cms.Core.Models.PublishedContent;
using UmbracoProject.App_Code.Models;

namespace UmbracoProject.App_Code.Services
{
    public interface ISearchService
    {
        /// <summary>
        /// Get global search result
        /// </summary>
        /// <param name="searchString"></param>
        /// <returns></returns>
        List<GlobalSearchModel> GetPublishedContents(string searchTerm);
    }
}
