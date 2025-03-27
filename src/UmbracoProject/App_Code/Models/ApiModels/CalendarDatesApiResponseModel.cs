namespace UmbracoProject.App_Code.Models.ApiModels
{
    public class CalendarDatesApiResponseModel
    {
        public bool ShowCalendar { get; set; }
        public List<DateOnly>? Dates { get; set; }
        public DateOnly? StartDate { get; set; }
        public DateOnly? EndDate { get; set; }
        public string? CalendarHelperText { get; set; }
        public string? CalendarTitle { get; set; }
    }
}
