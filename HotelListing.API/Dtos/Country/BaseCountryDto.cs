using System.ComponentModel.DataAnnotations;

namespace HotelListing.API.Dtos.Country
{
    public abstract record BaseCountryDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string ShortName { get; set; }
    }
}
