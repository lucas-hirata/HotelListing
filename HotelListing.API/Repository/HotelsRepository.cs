using HotelListing.API.Contracts;
using HotelListing.API.Data;

namespace HotelListing.API.Repository
{
    public class HotelsRepository : GenericRepository<Hotel>, IHotelsRepository
    {
        private readonly HotelListingDbContext _dbContext;

        public HotelsRepository(HotelListingDbContext dbContext) : base(dbContext)
        {
            this._dbContext = dbContext;
        }
    }
}
