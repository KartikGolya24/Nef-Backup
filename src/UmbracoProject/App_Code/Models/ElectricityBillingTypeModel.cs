namespace UmbracoProject.App_Code.Models
{
    public class ElectricityBillingTypeModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Tag { get; set; }
        public bool IsTagVisible {  get; set; }
        public decimal Price {  get; set; }
        public string PriceUnit {  get; set; }
        public decimal SupplementPrice {  get; set; }
        public string SupplementPriceUnit {  get; set; }
    }
}
