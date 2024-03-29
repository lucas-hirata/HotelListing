﻿namespace HotelListing.API.Data;

public record Country
{
    public int Id { get; set;}
    public string Name { get; set;}
    public string ShortName { get; set;}

    public virtual IEnumerable<Hotel> Hotels { get; set;}
}