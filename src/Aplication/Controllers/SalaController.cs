using Microsoft.AspNetCore.Mvc;
using src.Application.Dtos;
using src.Domain.Services.Interface;

namespace src.Application.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SalaController : ControllerBase
{
    private readonly ISalaService _salaService;

    public SalaController(ISalaService salaService)
    {
        _salaService = salaService;
    }

    // GET /api/salas
    [HttpGet("all")]
    public async Task<ActionResult<IEnumerable<SalaDto>>> GetAll()
    {
        var lista = await _salaService.GetAllSalas();
        if (!lista.Any())
        {
            return NoContent();
        }
        return Ok(lista);
    }

    // GET /api/Sala/{id}
    [HttpGet("{id:long}")]
    public async Task<ActionResult<SalaDto>> GetById(long id)
    {
        var sala = await _salaService.GetSalaById(id);
        if (sala == null)
        {
            return NotFound();
        }
        return Ok(sala);
       
    }

    // PUT /api/Sala/   (apenas atualizar)
    [HttpPut("update")]
    public async Task<IActionResult> Update([FromBody] SalaDto dto)
    {
        await _salaService.UpdateSala(dto);
        return Ok();
    }
}
