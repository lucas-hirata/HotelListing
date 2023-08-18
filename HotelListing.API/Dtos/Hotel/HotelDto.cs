namespace HotelListing.API.Dtos.Hotel;

public record HotelDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public double Rating { get; set; }
    public int CountryId { get; set; }
}
