namespace UmbracoProject.App_Code.Models
{
    public class ResponseModel
    {
        public object? Data { get; set; }
        public bool IsSucceeded { get; set; }
        public string? Error { get; set; }
    }
}
