using System.Linq; 
using Microsoft.AspNetCore.Mvc;
using src.Application.Dtos;
using src.Domain.Services.Interface;
using src.Persistence.Repositories.Interfaces;

namespace src.Application.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LaboratorioController : ControllerBase
{
    private readonly ILaboratorioService _service;
    public LaboratorioController(ILaboratorioService service)
    {
        _service = service;
    }

    [HttpGet("all")]
    public async Task<IActionResult> GetAll()
    {
        var lista = await _service.GetAllLaboratorios();
        if (!lista.Any())
        {
            return NoContent();
        }
        return Ok(lista);
    }

    [HttpGet("{id:long}")]
    public async Task<IActionResult> GetById(long id)
    {
        var lab = await _service.GetLaboratorioById(id);
        if (lab == null)
        {
            return NotFound();
        }
        return Ok(lab);
    }

    [HttpPut("update")]
    public async Task<IActionResult> Update([FromBody] LaboratorioDto dto)
    {
        await _service.UpdateLaboratorio(dto);
        return Ok();
    }
}
