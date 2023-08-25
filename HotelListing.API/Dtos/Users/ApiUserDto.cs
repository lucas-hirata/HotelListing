using System.ComponentModel.DataAnnotations;

namespace HotelListing.API.Dtos.Users;

public record ApiUserDto : LoginDto
{
    [Required]
    public string FirstName { get; set; }
    [Required]
    public string LastName { get; set; }
}
