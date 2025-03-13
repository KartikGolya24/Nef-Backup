using Newtonsoft.Json;
using RestSharp;
using UmbracoProject.App_Code.Helpers;
using UmbracoProject.App_Code.Models.ApiModels;

namespace UmbracoProject.App_Code.Services
{
    public class PackagesService : IPackagesService
    {
        private readonly IConfiguration _configuration;
        private string _clientId => _configuration.GetValue<string>("X-Client-Id") ?? "b761a75a-f3dd-487a-8d45-ffc683b12d14";
        private string _clientSecret => _configuration.GetValue<string>("X-Client-Secret") ?? "57a2ff46-af5c-44dd-a2e3-da58a0819bf4t";
        private string _apiBaseUrl => _configuration.GetValue<string>("ApiBaseUrl") ?? "https://productsapi.nef.dk";

        public PackagesService(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        #region Get ChargingPackages
        public async Task<List<ChargingPackagesModel>> ChargingPackages()
        {
            try
            {
                RestResponse restResponse = await GetResponse(PackageHelper.ChargingPackagesEndPoints);
                string actualJson = JsonConvert.DeserializeObject<string>(restResponse.Content ?? string.Empty) ?? string.Empty;
                return JsonConvert.DeserializeObject<List<ChargingPackagesModel>>(actualJson) ?? new();
            }
            catch (Exception)
            {
                return new();
            }
        }
        #endregion Get ChargingPackages End

        #region Get FiberPackages
        public async Task<List<FiberPackagesModel>> FiberPackages()
        {
            try
            {
                RestResponse restResponse = await GetResponse(PackageHelper.FiberPackagesEndPoints);
                string actualJson = JsonConvert.DeserializeObject<string>(restResponse.Content ?? string.Empty) ?? string.Empty;
                return JsonConvert.DeserializeObject<List<FiberPackagesModel>>(actualJson) ?? new();
            }
            catch (Exception)
            {
                return new();
            }
        }
        #endregion Get FiberPackages End    
        
        #region Get TvPackages
        public async Task<List<TvPackagesModel>> TvPackages()
        {
            try
            {
                RestResponse restResponse = await GetResponse(PackageHelper.TvPackagesEndPoints);
                string actualJson = JsonConvert.DeserializeObject<string>(restResponse.Content ?? string.Empty) ?? string.Empty;
                return JsonConvert.DeserializeObject<List<TvPackagesModel>>(actualJson) ?? new();
            }
            catch (Exception)
            {
                return new();
            }
        }
        #endregion Get TvPackages End

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
