using Microsoft.AspNetCore.Mvc;
using UmbracoProject.App_Code.Models.ApiModels;
using UmbracoProject.App_Code.Services;

namespace UmbracoProject.App_Code.Controllers
{
    [Route("packages")]
    public class PackagesController : Controller
    {
        private readonly IPackagesService _packagesService;

        public PackagesController(IPackagesService packagesService)
        {
            _packagesService = packagesService;
        }

        [HttpGet("get-tv-packages")]
        public async Task<IActionResult> GetTvPackages()
        {
            List<TvPackagesModel> tvPackages = await _packagesService.TvPackages();
            return PartialView("~/Views/Partials/_TvPackagesForPurchaseFlow.cshtml", tvPackages);
        }
        
        [HttpGet("get-fiber-packages")]
        public async Task<IActionResult> GetFiberPackages()
        {
            List<FiberPackagesModel> fiberPackages = await _packagesService.FiberPackages();
            return PartialView("~/Views/Partials/_FiberPackagesForPurchaseFlow.cshtml", fiberPackages);
        }
    }
}
