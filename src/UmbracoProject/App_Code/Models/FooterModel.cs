using Umbraco.Cms.Core.Models.PublishedContent;

namespace UmbracoProject.App_Code.Models
{
    public class FooterModel
    {
        public IPublishedElement FooterContent { get; set; }
        public IPublishedElement FooterSettings { get; set; }
        public string FooterName { get; set; }

    }
}
