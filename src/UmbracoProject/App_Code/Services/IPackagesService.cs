using UmbracoProject.App_Code.Models.ApiModels;

namespace UmbracoProject.App_Code.Services
{
    public interface IPackagesService
    {
        /// <summary>
        /// Get all charging packages
        /// </summary>
        /// <returns></returns>
        Task<List<ChargingPackagesModel>> ChargingPackages();

        /// <summary>
        /// Get all fiber packages
        /// </summary>
        /// <returns></returns>
        Task<List<FiberPackagesModel>> FiberPackages();

        /// <summary>
        /// Get all tv packages
        /// </summary>
        /// <returns></returns>
        Task<List<TvPackagesModel>> TvPackages();
    }
}
