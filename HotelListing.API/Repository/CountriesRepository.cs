using HotelListing.API.Contracts;
using HotelListing.API.Data;
using Microsoft.EntityFrameworkCore;

namespace HotelListing.API.Repository;

public class CountriesRepository : GenericRepository<Country>, ICountriesRepository
{
    private readonly HotelListingDbContext _dbContext;

    public CountriesRepository(HotelListingDbContext dbContext) : base(dbContext)
    {
        this._dbContext = dbContext;
    }

    public async Task<Country> GetDetails(int id)
    {
        return await _dbContext.Countries
            .Include(q => q.Hotels)
            .FirstOrDefaultAsync(q => q.Id == id);
    }
}
