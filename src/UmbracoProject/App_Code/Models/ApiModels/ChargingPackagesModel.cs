namespace UmbracoProject.App_Code.Models.ApiModels
{
    public class ChargingPackagesModel
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int? SubscriptionPrice { get; set; }
        public string? subscriptionPriceUnit { get; set; }
        public int? InitialPrice { get; set; }
        public string? InitialPriecUnit { get; set; }
        public string? InitialPricePostfix { get; set; }
        public int? ServiceagreementPrice { get; set; }
        public string? ServiceagreementPriceUnit { get; set; }
        public string? Disclaimer { get; set; }
        public string? orderlink { get; set; }
        public string? buttonOrderText { get; set; }
        public List<UspModel>? usps { get; set; }
    }
}
