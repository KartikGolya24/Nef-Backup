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

        [HttpGet("getChargingPackages")]
        public async Task<IActionResult> GetChargingPackages()
        {
            List<ChargingPackagesModel> chargingPackages = await _packagesService.ChargingPackages();
            return Ok(chargingPackages);
        }
    }
}
