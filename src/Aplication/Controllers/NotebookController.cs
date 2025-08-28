using System.Linq; 
using Microsoft.AspNetCore.Mvc;
using src.Application.Dtos;
using src.Domain.Model;
using src.Domain.Services.Interface;
using src.Persistence.Repositories.Interfaces;

namespace src.Application.Controllers;

[ApiController]
[Route("api/[controller]")]
public class NotebookController : ControllerBase
{
    private readonly INotebookService _service;
    public NotebookController(INotebookService service)
    {
        _service = service;
    }

    // GET /api/notebooks
    [HttpGet]
    public async Task<ActionResult<IEnumerable<NotebookDto>>> GetAll()
    {
        var lista = await _service.GetAllNotebooks();
        if (!lista.Any())
        {
            return NoContent();
        }
        return Ok(lista);
    }

    // GET /api/notebooks/{id}
    [HttpGet("{id:long}")]
    public async Task<ActionResult<NotebookDto>> GetById(long id)
    {
        var r = await _service.GetNotebookById(id);
        if (r == null)
        {
            return NoContent();
        }
        return Ok(r);
    }

    // POST /api/notebooks
    [HttpPost("create")]
    public async Task<IActionResult> Create([FromBody] NotebookCreateDto dto)
    {
        await _service.CreateNotebook(dto);
        return Ok();
    }

    // PUT /api/notebooks/{id}
    [HttpPut("update")]
    public async Task<IActionResult> Update([FromBody] NotebookDto dto)
    {
        await _service.UpdateNotebook(dto);
        return Ok();
    }

    // DELETE /api/notebooks/{id}
    [HttpDelete("{id:long}")]
    public async Task<IActionResult> Delete(long id)
    {
        await _service.DeleteNotebook(id);
        return Ok();
    }
}
