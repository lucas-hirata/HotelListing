using AutoMapper;
using HotelListing.API.Data;
using HotelListing.API.Dtos.Country;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HotelListing.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CountriesController : ControllerBase
{
    private readonly HotelListingDbContext _context;
    private readonly IMapper _mapper;

    public CountriesController(HotelListingDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    // GET: api/Countries
    [HttpGet]
    public async Task<ActionResult<IEnumerable<CountryDto>>> GetCountries()
    {
        var countries = await _context.Countries.ToListAsync();
        var result = _mapper.Map<List<CountryDto>>(countries);
        return Ok(result);
    }

    // GET: api/Countries/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Country>> GetCountry(int id)
    {
        var country = await _context.Countries
            .Include(q => q.Hotels)
            .FirstOrDefaultAsync(q => q.Id == id);

        if (country == null)
        {
            return NotFound();
        }

        var result = _mapper.Map<CountryDetailsDto>(country);

        return Ok(result);
    }

    // PUT: api/Countries/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutCountry(int id, CountryDto countryDto)
    {
        if (id != countryDto.Id)
        {
            return BadRequest();
        }

        _context.Entry(countryDto).State = EntityState.Modified;

        var country = await _context.Countries.FindAsync(id);

        if (country == null)
        {
            return NotFound();
        }

        _mapper.Map(countryDto, country);

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!CountryExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    // POST: api/Countries
    [HttpPost]
    public async Task<ActionResult<Country>> PostCountry(CreateCountryDto createCountry)
    {
        var country = _mapper.Map<Country>(createCountry);

        _context.Countries.Add(country);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetCountry", new { id = country.Id }, country);
    }

    // DELETE: api/Countries/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCountry(int id)
    {
        var country = await _context.Countries.FindAsync(id);
        if (country == null)
        {
            return NotFound();
        }

        _context.Countries.Remove(country);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool CountryExists(int id)
    {
        return _context.Countries.Any(e => e.Id == id);
    }
}
