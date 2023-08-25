using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace HotelListing.API.Data.Configuration;

public class HotelConfiguration : IEntityTypeConfiguration<Hotel>
{
    public void Configure(EntityTypeBuilder<Hotel> builder)
    {
        builder.HasData(
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
