namespace UmbracoProject.App_Code.Helpers
{
    public static class CommonHelper
    {
        public static string GetTagIconPosition(string dropPostion)
        {
            string tagImagePosition = string.Empty;
            switch (dropPostion)
            {
                case "right-top":
                    tagImagePosition = "img1";
                    break;

                case "left-bottom":
                    tagImagePosition = "img2";
                    break;

                case "right-bottom":
                    tagImagePosition = "img1 top-auto";
                    break;

                case "left-top":
                    tagImagePosition = "img3";
                    break;
            }

            return tagImagePosition;

        }
    }
}
