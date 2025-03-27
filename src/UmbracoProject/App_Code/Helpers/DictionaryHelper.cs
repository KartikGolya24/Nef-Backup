using Umbraco.Cms.Core.Services;

namespace UmbracoProject.App_Code.Helpers
{
    public class DictionaryHelper
    {
        private readonly ILocalizationService _localizationService;

        public DictionaryHelper(ILocalizationService localizationService)
        {
            _localizationService = localizationService;
        }
        public string GetDictionaryValue(string key)
        {
            var dictionaryItem = _localizationService.GetDictionaryItemByKey(key);
            var data = "";
            if (dictionaryItem != null)
            {
                var translation = dictionaryItem.Translations.SingleOrDefault(x => x.LanguageIsoCode.Equals("da-DK"));
                if (translation != null)
                {
                    data = translation.Value;
                }
            }
            return data;
        }
    }
}
