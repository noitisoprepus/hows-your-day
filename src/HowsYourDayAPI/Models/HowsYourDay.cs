using System;

namespace HowsYourDayAPI.Models
{
    public class User
    {
        public int Id { get; set; }
        public required string Username { get; set; }
        public required string Password { get; set; }
        public DateTime CreationDate { get; set; }
    }

    public class Day
    {
        public int Id { get; set; }
        public required User User { get; set; }
        public int Rating { get; set; }
        public string? Comment { get; set; }
    }
}