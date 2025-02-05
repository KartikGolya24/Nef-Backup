using Umbraco.Cms.Core.Models.PublishedContent;

namespace UmbracoProject.App_Code.Helpers
{
    public static class ImageOptimizeHelper
    {
        public static string? GetWebp(this IPublishedContent? media)
        {
            string? url = string.Empty;
            if (media != null)
            {
                int quality = 1;
                var mb = media.Value<int>("umbracoBytes") * 0.000001;
                if (Math.Round(mb, 1) <= 0.6)
                {
                    quality = 100;
                }
                else if (Math.Round(mb, 1) >= 0.7 && Math.Round(mb, 1) <= 1)
                {
                    quality = 50;
                }
                else if (mb >= 1 && mb <= 1.6)
                {
                    quality = 40;
                }
                else
                {
                    quality = 5;
                }

                url = media?.Url();
                if (!url.IsNullOrWhiteSpace() && !Path.GetExtension(url).Equals(".svg"))
                {
                    if (quality == 0)
                    {
                        url = $"{url}?format=webp";
                    }
                    else
                    {
                        url = $"{url}?format=webp&quality={quality}";
                    }
                }
            }

            return url;
        }

        public static string GetWebp(this IPublishedContent? media, int width, int height)
        {
            string url = string.Empty;
            if (media != null)
            {
                int quality = 80;
                url = media?.Url() ?? "";
                if (!url.IsNullOrWhiteSpace() && !Path.GetExtension(url).Equals(".svg"))
                {
                    url = $"{url}?format=webp&quality={quality}&width={width}&height={height}";
                }
            }

            return url;
        }

        public static string? GetWebpFormatLogo(this IPublishedContent? media)
        {
            string? url = string.Empty;

            if (media != null)
            {
                int quality = 1;
                var mb = media.Value<int>("umbracoBytes") * 0.000001;
                if (Math.Round(mb, 1) <= 0.6)
                {
                    quality = 40;
                }
                else if (Math.Round(mb, 1) >= 0.7 && Math.Round(mb, 1) <= 1)
                {
                    quality = 20;
                }
                else if (mb >= 1 && mb <= 1.6)
                {
                    quality = 10;
                }
                else
                {
                    quality = 5;
                }

                url = media?.Url();
                if (!url.IsNullOrWhiteSpace() && !Path.GetExtension(url).Equals(".svg"))
                {
                    if (quality == 0)
                    {
                        url = $"{url}?format=webp";
                    }
                    else
                    {
                        url = $"{url}?format=webp&quality={quality}";
                    }
                }
            }

            return url;
        }
    }
}
