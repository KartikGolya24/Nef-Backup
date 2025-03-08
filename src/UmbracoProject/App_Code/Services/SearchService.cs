using Examine;
using MailKit.Search;
using Org.BouncyCastle.Crypto;
using Umbraco.Cms.Core;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Web.Common;
using UmbracoProject.App_Code.Models;

namespace UmbracoProject.App_Code.Services
{
    public class SearchService : ISearchService
    {
        #region Global Variables

        private readonly IPublishedContentQuery _publishedContentQuery;
        private readonly IExamineManager _examineManager;

        #endregion Global Variables End

        #region Constructor
        public SearchService(IPublishedContentQuery publishedContentQuery,IExamineManager examineManager)
        {
            _publishedContentQuery = publishedContentQuery;
            _examineManager = examineManager;
        }

        #endregion Constructor End

        #region GetPublishedContents
        public List<GlobalSearchModel> GetPublishedContents(string searchTerm)
        {
            List<GlobalSearchModel> result = new();
            try
            {
                var searchResult = _publishedContentQuery.Search(searchTerm).Where(x => x?.Content?.TemplateId > 0);

                foreach (var item in searchResult)
                {
                    if (item?.Content?.TemplateId != null && item.Content.TemplateId > 0)
                    {
                        var parentName = string.IsNullOrWhiteSpace(item?.Content.Parent?.Name) ? "" : $"{item?.Content.Parent?.Name}-";
                        result.Add(new GlobalSearchModel() { NodeName = $"{parentName}{item?.Content.Name}", Url = item?.Content.Url() });
                    }
                }

                return result;
            }
            catch (Exception)
            {
                return result;
            }
        }
        #endregion GetPublishedContents End

    }
}
