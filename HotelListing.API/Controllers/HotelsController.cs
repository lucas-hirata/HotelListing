using AutoMapper;
using HotelListing.API.Contracts;
using HotelListing.API.Data;
using HotelListing.API.Dtos.Hotel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HotelListing.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class HotelsController : ControllerBase
{
    private readonly IHotelsRepository _hotelsRepository;
    private readonly IMapper _mapper;

    public HotelsController(IHotelsRepository hotelsRepository, IMapper mapper)
    {
        _hotelsRepository = hotelsRepository;
        this._mapper = mapper;
    }

    // GET: api/Hotels
    [HttpGet]
    public async Task<ActionResult<IEnumerable<HotelDto>>> GetHotels()
    {
        var hotels = await _hotelsRepository.GetAllAsync();
        var result = _mapper.Map<List<HotelDto>>(hotels);
        return Ok(result);
    }

    // GET: api/Hotels/5
    [HttpGet("{id}")]
    public async Task<ActionResult<HotelDto>> GetHotel(int id)
    {
        var hotel = await _hotelsRepository.GetAsync(id);

        if (hotel == null) return NotFound();

        var result = _mapper.Map<HotelDto>(hotel);

        return Ok(result);
    }

    // PUT: api/Hotels/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutHotel(int id, HotelDto hotelDto)
    {
        if (id != hotelDto.Id) return BadRequest();

        var hotel = await _hotelsRepository.GetAsync(id);

        if (hotel == null) return NotFound();

        _mapper.Map(hotelDto, hotel);

        try
        {
            await _hotelsRepository.UpdateAsync(hotel);
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!await HotelExists(id))
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

    // POST: api/Hotels
    [HttpPost]
    public async Task<ActionResult<HotelDto>> PostHotel(BaseHotelDto baseHotelDto)
    {
        var hotel = _mapper.Map<Hotel>(baseHotelDto);
        var result = await _hotelsRepository.AddAsync(hotel);
        var hotelDto = _mapper.Map<HotelDto>(result);
        return CreatedAtAction("GetHotel", new { id = hotelDto.Id }, hotelDto);
    }

    // DELETE: api/Hotels/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteHotel(int id)
    {
        if (!await HotelExists(id)) return NotFound();

        await _hotelsRepository.DeleteAsync(id);

        return NoContent();
    }

    private async Task<bool> HotelExists(int id)
    {
        return await _hotelsRepository.Exists(id);
    }
}
