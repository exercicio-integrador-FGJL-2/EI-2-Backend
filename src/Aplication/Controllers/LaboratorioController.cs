using System.Linq; 
using Microsoft.AspNetCore.Mvc;
using src.Application.Dtos;
using src.Persistence.Repositories.Interfaces;

namespace src.Application.Controllers;

[ApiController]
[Route("api/labs")]
public class LaboratoriosController : ControllerBase
{
    private readonly ILaboratorioRepository _repo;
    public LaboratoriosController(ILaboratorioRepository repo) => _repo = repo;

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var list = await _repo.GetAllAsync(); 
        var resp = list.Select(l => new LaboratorioResponseDto(
            l.Id, l.Nome, l.QtdComputadores, l.ConfigComputadores, l.Descricao
        ));
        return Ok(resp);
    }

    [HttpGet("{id:long}")]
    public async Task<IActionResult> GetById(long id)
    {
        var l = await _repo.GetByIdAsync(id); 
        if (l is null) return NotFound();
        return Ok(new LaboratorioResponseDto(
            l.Id, l.Nome, l.QtdComputadores, l.ConfigComputadores, l.Descricao
        ));
    }

    [HttpPut("{id:long}")]
    public async Task<IActionResult> Update(long id, [FromBody] LaboratorioUpdateDto dto)
    {
        if (dto is null) return BadRequest();

        var l = await _repo.GetByIdAsync(id); 
        if (l is null) return NotFound();

        l.Nome = dto.Nome;
        l.QtdComputadores = dto.QtdComputadores;
        l.ConfigComputadores = dto.ConfigComputadores;
        l.Descricao = dto.Descricao;

        _repo.Update(l);
        await _repo.SaveChangesAsync(); 
        return NoContent();
    }
}
