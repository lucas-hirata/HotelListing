using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HotelListing.API.Data;

public class HotelListingDbContext : IdentityDbContext<ApiUser>
{
    public HotelListingDbContext(DbContextOptions options) : base(options) { }

    public DbSet<Hotel> Hotels { get; set; }
    public DbSet<Country> Countries { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Country>().HasData(
            new
            {
                Id = 1,
                Name = "Brazil",
                ShortName = "BR",
            },
            new
            {
                Id = 2,
                Name = "Bahamas",
                ShortName = "BS",
            },
            new
            {
                Id = 3,
                Name = "Italy",
                ShortName = "IT",
            }
        );
        modelBuilder.Entity<Hotel>().HasData(
            new
            {
                Id = 1,
                Name = "Hotel BR",
                Address = "Rua talz, bairro",
                CountryId = 1,
                Rating = 2.5
            },
            new
            {
                Id = 2,
                Name = "Hotel BS",
                Address = "Uau que lugar, lindo",
                CountryId = 2,
                Rating = 3.5
            },
            new
            {
                Id = 3,
                Name = "Hotel Pizza",
                Address = "Rua pizza, pizza",
                CountryId = 3,
                Rating = 5.0
            }
        );
    }
}
