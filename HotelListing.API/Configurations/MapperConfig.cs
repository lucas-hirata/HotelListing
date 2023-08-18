using AutoMapper;
using HotelListing.API.Data;
using HotelListing.API.Dtos.Country;

namespace HotelListing.API.Configurations;

public class MapperConfig : Profile
{
    public MapperConfig()
    {
        CreateMap<Country, CreateCountryDto>().ReverseMap();
        CreateMap<Country, CountryDto>().ReverseMap();
    }
}
