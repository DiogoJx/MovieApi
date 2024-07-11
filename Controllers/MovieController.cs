using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.Data.Dtos;
using WebApplication1.Models;

namespace WebApplication1.Controllers;

[ApiController]
[Route("[controller]")]
public class MovieController : ControllerBase
{
    private MovieContext _context;
    private IMapper _mapper;

    public MovieController(MovieContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;

    }

    /// <summary>
    /// Adiciona um filme ao banco de dados
    /// </summary>
    /// <param name="filmeDto">Objeto com os campos necessários para criação de um filme</param>
    /// <returns>IActionResult</returns>
    /// <response code="201">Caso inserção seja feita com sucesso</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]

    [HttpPost]
    public IActionResult AddMovie([FromBody] CreateMovieDto movieDto)
    {
        Movie movie = _mapper.Map<Movie>(movieDto);

        _context.Movies.Add(movie);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetMovieById), new { id = movie.Id }, movie);
    }


    [HttpGet]
    public IEnumerable<ReadMovieDto> GetMovies([FromQuery] int skip = 0, [FromQuery] int take = 50)
    {
        return _mapper.Map<List<ReadMovieDto>>(_context.Movies.Skip(skip).Take(take));
    }

    [HttpGet("{id}")]
    public IActionResult GetMovieById(int id)
    {
        var movie = _context.Movies.FirstOrDefault(movie => movie.Id == id );

        if (movie == null) return NotFound();

        var movieDto = _mapper.Map<ReadMovieDto>(movie);

        return Ok(movieDto);

    }
    [HttpPut("{id}")]
    public IActionResult UpdateMovie(int id, UpdateMovieDto movieDto)
    {
        var movie = _context.Movies.FirstOrDefault(movie => movie.Id == id);

        if (movie == null) return NotFound();

        _mapper.Map(movieDto, movie);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpPatch("{id}")]

    public IActionResult PatchMovie(int id, JsonPatchDocument<UpdateMovieDto> patch)
    {
        var movie = _context.Movies.FirstOrDefault(movie => movie.Id == id);

        if (movie == null) return NotFound();

        var movieForUpdate = _mapper.Map<UpdateMovieDto>(movie);

        patch.ApplyTo(movieForUpdate, ModelState);

        if (!TryValidateModel(movieForUpdate))
        {
            return ValidationProblem();
        }

        _mapper.Map(movieForUpdate, movie );

        _context.SaveChanges();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteMovie(int id) {
        var movie = _context.Movies.FirstOrDefault(movie => movie.Id == id);

        if (movie == null) return NotFound();

        _context.Movies.Remove(movie);
        _context.SaveChanges();
        return NoContent();
    }

}
