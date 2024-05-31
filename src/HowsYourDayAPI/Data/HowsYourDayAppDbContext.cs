using HowsYourDayAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace HowsYourDayAPI.Data
{
    public class HowsYourDayAppDbContext: DbContext
    {
        public HowsYourDayAppDbContext(DbContextOptions<HowsYourDayAppDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Day> Days { get; set; }
    }
}