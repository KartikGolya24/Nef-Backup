using Newtonsoft.Json;
using RestSharp;
using UmbracoProject.App_Code.Helpers;
using UmbracoProject.App_Code.Models;
using UmbracoProject.App_Code.Models.ApiModels;

namespace UmbracoProject.App_Code.Services
{
    public class PurchaseFlowService : IPurchaseFlowService
    {
        #region Global Variables
        private readonly IConfiguration _configuration;
        private string _clientId => _configuration.GetValue<string>("X-Client-Id") ?? "b761a75a-f3dd-487a-8d45-ffc683b12d14";
        private string _clientSecret => _configuration.GetValue<string>("X-Client-Secret") ?? "57a2ff46-af5c-44dd-a2e3-da58a0819bf4t";
        private string _apiBaseUrl => _configuration.GetValue<string>("ApiBaseUrl") ?? "https://productsapi.nef.dk";

        #endregion Global Variables End

        public PurchaseFlowService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        #region Get Packages
        public async Task<List<ChargingPackagesModel>> GetChargingPackagesAsync()
        {
            try
            {
                RestResponse restResponse = await GetResponse(PackageHelper.ChargingPackagesEndPoint);
                return JsonConvert.DeserializeObject<List<ChargingPackagesModel>>(restResponse.Content ?? string.Empty) ?? new();
            }
            catch (Exception)
            {
                return new();
            }
        }

        public async Task<List<FiberPackagesModel>> GetFiberPackagesAsync()
        {
            try
            {
                RestResponse restResponse = await GetResponse(PackageHelper.FiberPackagesEndPoint);
                return JsonConvert.DeserializeObject<List<FiberPackagesModel>>(restResponse.Content ?? string.Empty) ?? new();
            }
            catch (Exception)
            {
                return new();
            }
        }
           
        public async Task<List<TvPackagesModel>> GetTvPackagesAsync()
        {
            try
            {
                RestResponse restResponse = await GetResponse(PackageHelper.TvPackagesEndPoint);
                return JsonConvert.DeserializeObject<List<TvPackagesModel>>(restResponse.Content ?? string.Empty) ?? new();
            }
            catch (Exception)
            {
                return new();
            }
        }
        #endregion Get Packages End

        #region CheckAddress
        public async Task<CheckAddressResponse> CheckAddressAsync(string adresseGUID)
        {
            RestResponse restResponse = await GetResponse($"{PackageHelper.CheckAddressEndPoint}?adresseGUID={adresseGUID}");
            return JsonConvert.DeserializeObject<CheckAddressResponse>(restResponse.Content ?? string.Empty) ?? new();
        }
        #endregion CheckAddress End

        #region get calendar dates
        public async Task<CalendarDatesApiResponseModel> GetCalendarDatesAsync(int orderType, string? adresseguid)
        {
            RestResponse restResponse = await GetResponse($"{PackageHelper.CalendarOptionsEndPoint}?orderType={orderType}&adresseguid={adresseguid}");
            return JsonConvert.DeserializeObject<CalendarDatesApiResponseModel>(restResponse.Content ?? string.Empty) ?? new();
        }
        #endregion get calendar dates end

        #region Call Api
        public async Task<RestResponse> GetResponse(string url)
        {
            IRestClient client = new RestClient(_apiBaseUrl);
            var request = new RestRequest(url, Method.Get);
            request.AddHeader(PackageHelper.ClientIdKey, _clientId);
            request.AddHeader(PackageHelper.ClientSecretKey, _clientSecret);

            return await client.ExecuteAsync(request);
        }

        #endregion Call Api End

    }
}
