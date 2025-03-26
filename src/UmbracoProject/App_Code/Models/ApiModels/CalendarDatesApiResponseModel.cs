namespace UmbracoProject.App_Code.Models.ApiModels
{
    public class CalendarDatesApiResponseModel
    {
        public bool ShowCalendar { get; set; }
        public List<DateTime>? Dates { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? CalendarHelperText { get; set; }
        public string? CalendarTitle { get; set; }
    }
}
