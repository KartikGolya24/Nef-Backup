namespace UmbracoProject.App_Code.Helpers
{
    public static class ConstantHelper
    {
        public static string IconList = "Icon";
        public static string NumberList = "Number";

        public static string IconStyle(string dropValue)
        {
            if (string.IsNullOrWhiteSpace(dropValue)) return "";

            string iconStyleTheme = string.Empty;
            switch (dropValue)
            {
                case "Circle":
                    iconStyleTheme= "circle_icon_list";
                    break;
                    
                case "Square":
                    iconStyleTheme= "square_icon_list";
                    break;   
            }

            return iconStyleTheme;
        }
    }
}
