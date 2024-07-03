using System.ComponentModel.DataAnnotations;

namespace Shared.DTOs.Day
{
    public class CreateDayDTO
    {
        [Required]
        public int Rating { get; set; }
        public string? Comment { get; set; } = null;
    }   
}