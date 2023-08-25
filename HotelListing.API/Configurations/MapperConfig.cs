using AutoMapper;
using HotelListing.API.Data;
using HotelListing.API.Dtos.Country;
using HotelListing.API.Dtos.Hotel;
using HotelListing.API.Dtos.Users;

namespace HotelListing.API.Configurations;

public class MapperConfig : Profile
{
    public MapperConfig()
    {
        CreateMap<Country, CreateCountryDto>().ReverseMap();
        CreateMap<Country, CountryDto>().ReverseMap();
        CreateMap<Country, CountryDetailsDto>().ReverseMap();

        CreateMap<Hotel, BaseHotelDto>().ReverseMap();
        CreateMap<Hotel, HotelDto>().ReverseMap();

        CreateMap<ApiUser, ApiUserDto>().ReverseMap();
    }
}
