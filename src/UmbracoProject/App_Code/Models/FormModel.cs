using Umbraco.Cms.Core.Trees;
using Umbraco.Forms.Core.Models;

namespace UmbracoProject.App_Code.Models
{
    public class FormViewModel
    {
        public Form Form { get; set; }
        public string ActionUrl { get; set; }

    }


    public class SunbeamStoryFormRequestModel
    {
        public Guid FormId { get; set; }
        public string fuldeNavn { get; set; }
        public string adresse { get; set; }
        public long telefon { get; set; }
        public string email { get; set; }
        public long gSRNNummer { get; set; }
        public string evtKommentar { get; set; }
        public string ReturnUrl { get; set; }
    }
}
