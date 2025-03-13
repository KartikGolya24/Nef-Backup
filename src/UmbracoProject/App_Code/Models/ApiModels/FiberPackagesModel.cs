namespace UmbracoProject.App_Code.Models.ApiModels
{
    public class FiberPackagesModel
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int? PriceMonthlyDKK { get; set; }
        public string? Priceprefix { get; set; }
        public string? Unit { get; set; }
        public string? LearnMore { get; set; }
        public string? Disclaimer { get; set; }
        public int? TemporaryPriceMonthlyDKK { get; set; }
        public int? TemporaryPriceDisclaimer { get; set; }
        public List<UspModel>? Usps { get; set; }
    }
}
