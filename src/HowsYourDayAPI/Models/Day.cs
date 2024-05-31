namespace HowsYourDayAPI.Models
{
    public class Day
    {
        public int Id { get; set; }
        public required User User { get; set; }
        public DateTime LogDate { get; set; }
        public int Rating { get; set; }
        public string? Comment { get; set; }
    }
}