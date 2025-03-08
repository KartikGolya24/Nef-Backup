using Microsoft.AspNetCore.Mvc;
using UmbracoProject.App_Code.Services;

namespace UmbracoProject.App_Code.Controllers
{
    [Route("GlobalSearch")]
    public class GlobalSearchController : Controller
    {
        private readonly ISearchService _searchService;

        public GlobalSearchController(ISearchService searchService)
        {
            _searchService = searchService;
        }

        [HttpGet("GetSearchResult")]
        public IActionResult GetSearchResult([FromQuery] string searchTerm)
        {
            var response = _searchService.GetPublishedContents(searchTerm);
            return PartialView("_SearchResults", response);
        }
    }
}
