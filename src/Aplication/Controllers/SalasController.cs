using System.Linq; 
using Microsoft.AspNetCore.Mvc;
using src.Application.Dtos;
using src.Persistence.Repositories.Interfaces;

namespace src.Application.Controllers;

[ApiController]
[Route("api/salas")]
public class SalasController : ControllerBase
{
    private readonly ISalaRepository _repo;
    public SalasController(ISalaRepository repo) => _repo = repo;

    // GET /api/salas
    [HttpGet]
    public async Task<ActionResult<IEnumerable<SalaResponseDto>>> GetAll()
    {
        var list = await _repo.GetAllAsync();
        var resp = list.Select(s => new SalaResponseDto(
            s.Id, s.Numero, s.Lugares, s.Projetor, s.Descricao
        ));
        return Ok(resp);
    }

    // GET /api/salas/{id}
    [HttpGet("{id:long}")]
    public async Task<ActionResult<SalaResponseDto>> GetById(long id)
    {
        var s = await _repo.GetByIdAsync(id);
        if (s is null) return NotFound();

        return Ok(new SalaResponseDto(
            s.Id, s.Numero, s.Lugares, s.Projetor, s.Descricao
        ));
    }

    // PUT /api/salas/{id}   (apenas atualizar)
    [HttpPut("{id:long}")]
    public async Task<IActionResult> Update(long id, [FromBody] SalaUpdateDto dto)
    {
        if (dto is null) return BadRequest();

        var s = await _repo.GetByIdAsync(id);
        if (s is null) return NotFound();

        
        s.Numero   = dto.Numero;
        s.Lugares  = dto.Lugares;
        s.Projetor = dto.Projetor;
        s.Descricao = dto.Descricao;

        var numeroDuplicado = await _repo.ExistsAsync(x => x.Numero == s.Numero && x.Id != s.Id);
        if (numeroDuplicado) return Conflict($"Já existe sala com número {s.Numero}.");

        _repo.Update(s);
        await _repo.SaveChangesAsync();
        return NoContent();
    }
}
