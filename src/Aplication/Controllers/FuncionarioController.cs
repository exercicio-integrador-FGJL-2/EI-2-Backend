using System.Linq; 
using Microsoft.AspNetCore.Mvc;
using src.Application.Dtos;
using src.Persistence.Repositories.Interfaces; 

namespace src.Application.Controllers;

[ApiController]
[Route("api/funcionarios")]
public class FuncionariosController : ControllerBase
{
    private readonly IFuncionarioRepository _repo;

    public FuncionariosController(IFuncionarioRepository repo)
        => _repo = repo;

    // GET /api/funcionarios
    [HttpGet]
    public async Task<ActionResult<IEnumerable<FuncionarioResponseDto>>> GetAll()
    {
        var list = await _repo.GetAllAsync();
        var resp = list.Select(f => new FuncionarioResponseDto(
            f.Matricula, f.Nome, f.Cargo, f.DAdmissao
        ));
        return Ok(resp);
    }

    // GET /api/funcionarios/{matricula}
    [HttpGet("{matricula:long}")]
    public async Task<ActionResult<FuncionarioResponseDto>> GetByMatricula(long matricula)
    {
        var f = await _repo.GetByIdAsync(matricula);
        if (f is null) return NotFound();

        return Ok(new FuncionarioResponseDto(
            f.Matricula, f.Nome, f.Cargo, f.DAdmissao
        ));
    }
}
