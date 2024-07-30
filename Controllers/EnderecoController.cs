using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.Data.Dtos;
using WebApplication1.Models;

namespace WebApplication1.Controllers;

[ApiController]
[Route("[controller]")]
public class EnderecoController : ControllerBase
{
    private MovieContext _context;
    private IMapper _mapper;

    public EnderecoController(MovieContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;

    }

    [HttpPost]
    public IActionResult AddEndereco([FromBody] CreateEnderecoDto enderecoDto)
    {
        Endereco endereco = _mapper.Map<Endereco>(enderecoDto);

        _context.Enderecos.Add(endereco);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetEnderecoById), new { id = endereco.Id }, endereco);
    }


    [HttpGet]
    public IEnumerable<ReadEnderecoDto> GetAllEndereco()
    {
        return _mapper.Map<List<ReadEnderecoDto>>(_context.Enderecos.ToList());
    }
    

    [HttpGet("{id}")]
    public IActionResult GetEnderecoById(int id)
    {
        var endereco = _context.Enderecos.FirstOrDefault(e => e.Id == id );

        if (endereco == null) return NotFound();

        var enderecoDto = _mapper.Map<ReadEnderecoDto>(endereco);

        return Ok(enderecoDto);

    }
    [HttpPut("{id}")]
    public IActionResult UpdateEndereco(int id, UpdateEnderecoDto enderecoDto)
    {
        var endereco = _context.Enderecos.FirstOrDefault(endereco => endereco.Id == id);

        if (endereco == null) return NotFound();
        _mapper.Map(enderecoDto, endereco);

        _context.SaveChanges();
        return NoContent();
    }

    [HttpPatch("{id}")]

    public IActionResult PatchEndereco(int id, JsonPatchDocument<UpdateEnderecoDto> patch)
    {
        var endereco = _context.Enderecos.FirstOrDefault(e => e.Id == id);

        if (endereco == null) return NotFound();

        var enderecoForUpdate = _mapper.Map<UpdateEnderecoDto>(endereco);

        patch.ApplyTo(enderecoForUpdate, ModelState);

        if (!TryValidateModel(enderecoForUpdate))
        {
            return ValidationProblem();
        }

        _mapper.Map(enderecoForUpdate, endereco );

        _context.SaveChanges();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteEndereco(int id) {
        var endereco = _context.Enderecos.FirstOrDefault(e => e.Id == id);

        if (endereco == null) return NotFound();

        _context.Enderecos.Remove(endereco);
        _context.SaveChanges();
        return NoContent();
    }

}
