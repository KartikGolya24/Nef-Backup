namespace UmbracoProject.App_Code.Helpers
{
    public static class PackageHelper
    {
        #region Api Header Credential Key
        public static string ClientIdKey = "X-Client-Id";
        public static string ClientSecretKey = "X-Client-Secret";
        #endregion Api Header Credential End Key

        #region Api EndPoints
        public static string ChargingPackagesEndPoints = "/api/ChargeProducts";
        public static string FiberPackagesEndPoints = "/api/FiberProducts";
        public static string TvPackagesEndPoints = "/api/TVProducts";
        #endregion Api EndPoints End
    }
}
