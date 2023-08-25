using AutoMapper;
using HotelListing.API.Contracts;
using HotelListing.API.Data;
using HotelListing.API.Dtos.Country;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HotelListing.API.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class CountriesController : ControllerBase
{
    private readonly ICountriesRepository _countriesRepository;
    private readonly IMapper _mapper;

    public CountriesController(ICountriesRepository countriesRepository, IMapper mapper)
    {
        _countriesRepository = countriesRepository;
        _mapper = mapper;
    }

    // GET: api/Countries
    [HttpGet]
    public async Task<ActionResult<IEnumerable<CountryDto>>> GetCountries()
    {
        var countries = await _countriesRepository.GetAllAsync();
        var result = _mapper.Map<List<CountryDto>>(countries);
        return Ok(result);
    }

    // GET: api/Countries/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Country>> GetCountry(int id)
    {
        var country = await _countriesRepository.GetDetails(id);

        if (country == null) return NotFound();

        var result = _mapper.Map<CountryDetailsDto>(country);

        return Ok(result);
    }

    // PUT: api/Countries/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutCountry(int id, CountryDto countryDto)
    {
        if (id != countryDto.Id) return BadRequest();

        var country = await _countriesRepository.GetAsync(id);

        if (country == null) return NotFound();

        _mapper.Map(countryDto, country);

        try
        {
            await _countriesRepository.UpdateAsync(country);
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!await CountryExists(id)) return NotFound();

            throw;
        }

        return NoContent();
    }

    // POST: api/Countries
    [HttpPost]
    public async Task<ActionResult<Country>> PostCountry(CreateCountryDto createCountry)
    {
        var country = _mapper.Map<Country>(createCountry);

        await _countriesRepository.AddAsync(country);

        return CreatedAtAction("GetCountry", new { id = country.Id }, country);
    }

    // DELETE: api/Countries/5
    [HttpDelete("{id}")]
    [Authorize(Roles = "Administrator")]
    public async Task<IActionResult> DeleteCountry(int id)
    {
        if (!await CountryExists(id)) return NotFound();

        await _countriesRepository.DeleteAsync(id);

        return NoContent();
    }

    private async Task<bool> CountryExists(int id)
    {
        return await _countriesRepository.Exists(id);
    }
}
