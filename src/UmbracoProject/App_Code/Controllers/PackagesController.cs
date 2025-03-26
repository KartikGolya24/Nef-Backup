using Microsoft.AspNetCore.Mvc;
using UmbracoProject.App_Code.Models.ApiModels;
using UmbracoProject.App_Code.Services;

namespace UmbracoProject.App_Code.Controllers
{
    [Route("packages")]
    public class PackagesController : Controller
    {
        private readonly IPurchaseFlowService _purchaseFlowService;

        public PackagesController(IPurchaseFlowService purchaseFlowService)
        {
            _purchaseFlowService = purchaseFlowService;
        }

        [HttpGet("get-tv-packages")]
        public async Task<IActionResult> GetTvPackages()
        {
            List<TvPackagesModel> tvPackages = await _purchaseFlowService.GetTvPackagesAsync();
            return PartialView("~/Views/Partials/_TvPackagesForPurchaseFlow.cshtml", tvPackages);
        }
        
        [HttpGet("get-fiber-packages")]
        public async Task<IActionResult> GetFiberPackages()
        {
            List<FiberPackagesModel> fiberPackages = await _purchaseFlowService.GetFiberPackagesAsync();
            return PartialView("~/Views/Partials/_FiberPackagesForPurchaseFlow.cshtml", fiberPackages);
        }
    }
}
