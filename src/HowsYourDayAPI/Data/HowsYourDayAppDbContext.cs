using HowsYourDayAPI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HowsYourDayAPI.Data
{
    public class HowsYourDayAppDbContext: IdentityDbContext<IdentityUser>
    {
        public HowsYourDayAppDbContext(DbContextOptions<HowsYourDayAppDbContext> options) : base(options)
        {
        }

        public DbSet<Day> Days { get; set; }
    }
}