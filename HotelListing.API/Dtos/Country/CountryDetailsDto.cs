using HotelListing.API.Dtos.Hotel;

namespace HotelListing.API.Dtos.Country;

public record CountryDetailsDto : BaseCountryDto
{
    public int Id { get; set; }

    public List<HotelDto> Hotels { get; set; }
}
