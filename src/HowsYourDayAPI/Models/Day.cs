namespace HowsYourDayAPI.Models
{
    public class Day
    {
        public required User UserId { get; set; }
        public DateTime LogDate { get; set; }
        public int Rating { get; set; }
        public string? Comment { get; set; }
    }
}