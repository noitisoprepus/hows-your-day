namespace HowsYourDayApp.Models
{
    public class DayEntry
    {
        public int Rating { get; set; }
        public string? Comment { get; set; }
        public DateTime LogDate { get; set; }
    }
}