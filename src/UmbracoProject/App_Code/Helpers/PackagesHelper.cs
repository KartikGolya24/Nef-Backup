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
        #endregion Api EndPoints End
    }
}
