namespace UmbracoProject.App_Code.Models.ApiModels
{
    public class TvPackagesModel
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int? PriceMonthlyDKK { get; set; }
        public string? Disclaimer { get; set; }
        public string? Priceprefix { get; set; }
        public int? TemporaryPriceMonthlyDKK { get; set; }
        public string? TemporaryPriceDisclaimer { get; set; }
        public string? Unit { get; set; }
        public List<Channel>? Channels { get; set; }
        public List<StreamingServy>? StreamingServies { get; set; }
        public List<UspModel>? Usps { get; set; }
        public int? ChannelsCount { get; set; }
        public List<Prioritizedchannel>? Prioritizedchannels { get; set; }
    }

    public class Channel
    {
        public string? Name { get; set; }
        public string? Logourl { get; set; }
    }

    public class Prioritizedchannel
    {
        public string? Name { get; set; }
        public string? Logourl { get; set; }
    }

    public class StreamingServy
    {
        public string? Name { get; set; }
        public string? Logourl { get; set; }
    }
}
