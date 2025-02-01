using HowsYourDayAPI.Data;
using HowsYourDayAPI.Models;
using HowsYourDayAPI.Services;
using Microsoft.EntityFrameworkCore;

namespace HowsYourDayTest
{
    public class DayServiceTests
    {
        private readonly HowsYourDayAppDbContext _context;
        private readonly DayService _sut;

        public DayServiceTests()
        {
            var options = new DbContextOptionsBuilder<HowsYourDayAppDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;
            _context = new HowsYourDayAppDbContext(options);
            _sut = new DayService(_context);
        }

        [Fact]
        public async Task GetDayById_ShouldReturnDay_WhenDayExists()
        {
            // Arrange
            var dayId = Guid.NewGuid();
            var day = new Day { DayId = dayId, UserId = "testuser", LogDate = DateTime.UtcNow, Rating = 5 };

            _context.Days.Add(day);
            await _context.SaveChangesAsync();

            // Act
            var result = await _sut.GetDayAsync(dayId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(dayId, result.DayId);
        }

        [Fact]
        public async Task GetDayById_ShouldReturnNull_WhenDayDoesNotExist()
        {
            // Arrange
            var dayId = Guid.NewGuid();

            // Act
            var result = await _sut.GetDayAsync(dayId);

            // Assert
            Assert.Null(result);
        }
    }
}