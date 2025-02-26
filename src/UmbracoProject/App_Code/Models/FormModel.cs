using Umbraco.Cms.Web.Common.PublishedModels;

namespace UmbracoProject.App_Code.Models
{
    public class FormViewModel
    {
        public Guid FormId { get; set; }
        public FormSectionFormBlock? FormContent { get; set; }
    }
}
