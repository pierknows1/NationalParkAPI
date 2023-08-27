using Microsoft.EntityFrameworkCore;


namespace NationalParks.Models
{
  public class ParksApiContext : DbContext
  {
    public DbSet<Park> Parks { get; set; }

    public ParksApiContext(DbContextOptions<ParksApiContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<Park>()
        .HasData(
            new Park { ParkId = 1, ParkName = "Grand Canyon", ParkCity = "Grand Canyon Village", ParkState = "Arizona", Rating = 9}, 
            new Park { ParkId = 2, ParkName = "Yosemite", ParkCity = "Yosemite National Park", ParkState = "California", Rating = 9},
            new Park { ParkId = 3, ParkName = "Death Valley", ParkCity = "Furnace Creek", ParkState = "California", Rating = 8},
            new Park { ParkId = 4, ParkName = "Hawaii Volcanoes", ParkCity = "Hawaii National Park", ParkState = "Hawaii", Rating = 10},
            new Park { ParkId = 5, ParkName = "RedWood", ParkCity = "Crescent City", ParkState = "California", Rating = 7}
    
        );
    }
  }
}
