using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.Data.Dtos;
using WebApplication1.Models;

namespace WebApplication1.Controllers;

[ApiController]
[Route("[controller]")]
public class CinemaController : ControllerBase
{
    private MovieContext _context;
    private IMapper _mapper;

    public CinemaController(MovieContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;

    }

    [HttpGet]
    public IEnumerable<ReadCinemaDto> GetAll() {
        return _mapper.Map<List<ReadCinemaDto>>(_context.Cinemas.ToList());
    }


    [HttpGet("{id}")]
    public IActionResult GetCinemaById(int id)
    {
        var cinema = _context.Cinemas.FirstOrDefault(c => c.Id == id);

        if (cinema == null)
        {
            return NotFound();
        }

        ReadCinemaDto readCinemaDto = _mapper.Map<ReadCinemaDto>(cinema);

        return Ok(readCinemaDto);

    }

    [HttpPost]
    public IActionResult AdicionarCinema([FromBody] CreateCinemaDto cinemaDto)
    {
        Cinema cinema = _mapper.Map<Cinema>(cinemaDto);

        _context.Cinemas.Add(cinema);
        _context.SaveChanges();

        return CreatedAtAction(nameof(GetCinemaById), new { Id = cinema.Id }, cinemaDto);

    }

    [HttpPut("{id}")]

    public IActionResult UpdateCinema([FromQuery] int id, [FromBody] UpdateCinemaDto updateCinema )
    {

        Cinema cinema = _context.Cinemas.FirstOrDefault(c => c.Id == id);

        if (cinema == null)
        {
            return NotFound();
        }

        _mapper.Map(updateCinema, cinema);
        _context.SaveChanges();

        return NoContent();

    }


    [HttpPut("{id}")]

    public IActionResult DeleteCinema(int id) {
        var cinema = _context.Cinemas.FirstOrDefault(c=> c.Id == id);

        if(cinema == null)
        {
            return NotFound();
        }
        _context.Cinemas.Remove(cinema);
        _context.SaveChanges();
        return NoContent(); }

}
