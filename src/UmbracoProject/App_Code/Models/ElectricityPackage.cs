namespace UmbracoProject.App_Code.Models
{
    public class ElectricityPackage
    {
        public string Heading { get; set; }
        public IEnumerable<string>? TextList { get; set; }
        public Decimal Price { get; set; }
        public string PriceUnit { get; set; }
        public Decimal CertificatePrice { get; set; }
        public string CertificatePriceUnit { get; set; }
    }
}
