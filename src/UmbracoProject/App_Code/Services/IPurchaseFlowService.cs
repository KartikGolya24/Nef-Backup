using MailKit.Search;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Math;
using UmbracoProject.App_Code.Models.ApiModels;
using static Lucene.Net.Store.Lock;

namespace UmbracoProject.App_Code.Services
{
    public interface IPurchaseFlowService
    {
        /// <summary>
        /// Get all charging packages
        /// </summary>
        /// <returns></returns>
        Task<List<ChargingPackagesModel>> GetChargingPackagesAsync();

        /// <summary>
        /// Get all fiber packages
        /// </summary>
        /// <returns></returns>
        Task<List<FiberPackagesModel>> GetFiberPackagesAsync();

        /// <summary>
        /// Get all tv packages
        /// </summary>
        /// <returns></returns>
        Task<List<TvPackagesModel>> GetTvPackagesAsync();

        /// <summary>
        /// Check address that tv/fiber product is available or not on that address
        /// </summary>
        /// <param name="adresseGUID"></param>
        /// <returns></returns>
        Task<CheckAddressResponse> CheckAddressAsync(string adresseGUID);

        /// <summary>
        /// Get all possible dates for order your fiber/tv products
        /// 1 = (Electricity) Supplier Change (In Figma: "Jeg ønsker at skifte til nef Strøm på min nuværende adresse")
        /// 2 = (Electricity) Move in (In Figma "Jeg flytter ind på leveringsadressen)"
        ///(Be aware with this type of order, the customer can also select dates before today)
        /// 3 = (Fiber/TV) - With this ordertype, you also need to provide the unique adressguid. That paremeter is called "adresseguid".
        /// </summary>
        /// <param name="orderType">

        /// </param>
        /// <param name="adresseguid"></param>
        /// <returns></returns>
        Task<CalendarDatesApiResponseModel> GetCalendarDatesAsync(int orderType,string? adresseguid);
    }
}
