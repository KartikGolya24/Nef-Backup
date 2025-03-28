namespace UmbracoProject.App_Code.Models.ApiModels
{
    public class ProductOrderRequestModel
    {
        public string? orderType { get; set; }
        public string? packageId { get; set; } = string.Empty;
        public string? packageName { get; set; } = string.Empty;
        public string? tvCategory { get; set; } = string.Empty;
        public string? deliveryAddress { get; set; } = string.Empty;
        public string? fullName { get; set; } = string.Empty;
        public string? cprNumber { get; set; } = string.Empty;
        public string? email { get; set; } = string.Empty;
        public string? telephoneNumber { get; set; } = string.Empty;
        public string? deliveryDate { get; set; } = string.Empty;
        public decimal totalPrice { get; set; }
        public bool isExtraPerson { get; set; }
        public string? extraPersonFullName { get; set; } = string.Empty;    
        public string? extraPersonCPRNumber { get; set; } = string.Empty;
        public string? addressType { get; set; } = string.Empty;
        public string? billingType { get; set; } = string.Empty;
        public bool hasOtherBillingAddress { get; set; }
        public string? otherBillingAddress { get; set; } = string.Empty;
        public bool isWirelessInternetAccess { get; set; }
    }
}
