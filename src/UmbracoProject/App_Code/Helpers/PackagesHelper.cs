namespace UmbracoProject.App_Code.Helpers
{
    public static class PackageHelper
    {
        #region Api Header Credential Key
        public static string ClientIdKey = "X-Client-Id";
        public static string ClientSecretKey = "X-Client-Secret";
        #endregion Api Header Credential End Key

        #region Api EndPoints
        public static string ChargingPackagesEndPoint = "/api/ChargeProducts";
        public static string FiberPackagesEndPoint = "/api/FiberProducts";
        public static string TvPackagesEndPoint = "/api/TVProducts";
        public static string CheckAddressEndPoint = "/api/CheckAddress";
        public static string CalendarOptionsEndPoint = "/api/CalendarOptions";
        public static string PruductDetailsSendApiEndPoint = "https://prod-49.northeurope.logic.azure.com/workflows/cadab5f01ced41f7a4505321b6800adc/triggers/manual/paths/invoke?api-version=2016-06-01&sp=%2Ftriggers%2Fmanual%2Frun&sv=1.0&sig=P-XsGeEsVpBTbTv4Q7klG26LXnLI-JHnmkhXXe_Sl-U";
        #endregion Api EndPoints End
    }
}
