using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace HotelListing.API.Data.Configuration;

public class CountryConfiguration : IEntityTypeConfiguration<Country>
{
    public void Configure(EntityTypeBuilder<Country> builder)
    {
        builder.HasData(
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
    }
}
