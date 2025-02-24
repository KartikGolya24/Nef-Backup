namespace UmbracoProject.App_Code.Helpers
{
    public static class CommonHelper
    {
        public static string GetTagIconPosition(string dropPostion)
        {
            string tagImagePosition = string.Empty;
            switch (dropPostion)
            {
                case "bottom-corner-right":
                    tagImagePosition = "img1";
                    break;

                case "top-corner-right":
                    tagImagePosition = "img11";
                    break;

                case "top-corner-left":
                    tagImagePosition = "img2";
                    break;

                case "top-left":
                    tagImagePosition = "img22";
                    break;

                case "top-center-left":
                    tagImagePosition = "img3";
                    break;

                case "bottom-left":
                    tagImagePosition = "img4";
                    break;

                case "slight-left-bottom":
                    tagImagePosition = "img5";
                    break;
            }

            return tagImagePosition;

        }

    }
}