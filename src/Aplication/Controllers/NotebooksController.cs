using System.Linq; 
using Microsoft.AspNetCore.Mvc;
using src.Application.Dtos;
using src.Domain.Model;
using src.Persistence.Repositories.Interfaces;

namespace src.Application.Controllers;

[ApiController]
[Route("api/notebooks")]
public class NotebooksController : ControllerBase
{
    private readonly INotebookRepository _repo;
    public NotebooksController(INotebookRepository repo) => _repo = repo;

    // GET /api/notebooks
    [HttpGet]
    public async Task<ActionResult<IEnumerable<NotebookResponseDto>>> GetAll()
    {
        var list = await _repo.GetAllAsync(); 
        var resp = list.Select(n => new NotebookResponseDto(
            n.Id, n.NroPatrimonio, n.DataAquisicao, n.Descricao
        ));
        return Ok(resp);
    }

    // GET /api/notebooks/{id}
    [HttpGet("{id:long}")]
    public async Task<ActionResult<NotebookResponseDto>> GetById(long id)
    {
        var n = await _repo.GetByIdAsync(id); 
        if (n is null) return NotFound();
        return Ok(new NotebookResponseDto(
            n.Id, n.NroPatrimonio, n.DataAquisicao, n.Descricao
        ));
    }

    // POST /api/notebooks
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] NotebookCreateDto dto)
    {
        if (dto is null) return BadRequest();

        // patrimônio único
        var exists = await _repo.ExistsAsync(x => x.NroPatrimonio == dto.NroPatrimonio); 
        if (exists) return Conflict($"Já existe notebook com patrimônio {dto.NroPatrimonio}.");

        var n = new Notebook
        {
            NroPatrimonio = dto.NroPatrimonio,
            DataAquisicao = dto.DataAquisicao,
            Descricao = dto.Descricao
        };

        await _repo.AddAsync(n);          
        await _repo.SaveChangesAsync();   

        var resp = new NotebookResponseDto(n.Id, n.NroPatrimonio, n.DataAquisicao, n.Descricao);
        return CreatedAtAction(nameof(GetById), new { id = n.Id }, resp);
    }

    // PUT /api/notebooks/{id}
    [HttpPut("{id:long}")]
    public async Task<IActionResult> Update(long id, [FromBody] NotebookUpdateDto dto)
    {
        if (dto is null) return BadRequest();

        var n = await _repo.GetByIdAsync(id);
        if (n is null) return NotFound();

        var duplicado = await _repo.ExistsAsync(x => x.NroPatrimonio == dto.NroPatrimonio && x.Id != id);
        if (duplicado) return Conflict($"Já existe notebook com patrimônio {dto.NroPatrimonio}.");

        n.NroPatrimonio = dto.NroPatrimonio;
        n.DataAquisicao = dto.DataAquisicao;
        n.Descricao = dto.Descricao;

        _repo.Update(n);
        await _repo.SaveChangesAsync(); 
        return NoContent();
    }

    // DELETE /api/notebooks/{id}
    [HttpDelete("{id:long}")]
    public async Task<IActionResult> Delete(long id)
    {
        var n = await _repo.GetByIdAsync(id);
        if (n is null) return NotFound();

        _repo.Remove(n);
        await _repo.SaveChangesAsync(); 
        return NoContent();
    }
}
