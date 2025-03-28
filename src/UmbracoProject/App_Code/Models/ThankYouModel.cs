using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Web.Common.PublishedModels;

namespace UmbracoProject.App_Code.Models
{
    public class ThankYouModel
    {
        public string Heading { get; set; }
        public string SuccessIcon { get; set; }
        public string SuccessTitle { get; set; }
        public string SuccessDescription { get; set; }
        public string ButtonText { get; set; }
        public string ButtonUrl { get; set; }
        public string ButtonTheme { get; set; }
        public string ButtonBorderColor { get; set; }
        public List<PositionImage> PositionImages { get; set; } = [];
    }
    
}
