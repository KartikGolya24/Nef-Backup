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

        [HttpGet("get-tv-package-list")]
        public async Task<IActionResult> GetTvPackageList()
        {
            return Ok(await _purchaseFlowService.GetTvPackagesAsync());
        }

        [HttpGet("get-fiber-package-list")]
        public async Task<IActionResult> GetFiberPackageList()
        {
            return Ok(await _purchaseFlowService.GetFiberPackagesAsync());
        }
    }
}
