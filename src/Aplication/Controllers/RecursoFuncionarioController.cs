using Microsoft.AspNetCore.Mvc;
using src.Application.Dtos;
using src.Domain.Services.Interface;

namespace src.Application.Controllers
{
    [Route("api/[controller]")]
    public class RecursoFuncionarioController : Controller
    {
        private readonly IRecursoFuncionarioService _recursoFuncionarioService;
        public RecursoFuncionarioController(IRecursoFuncionarioService recursoFuncionarioService)
        {
            _recursoFuncionarioService = recursoFuncionarioService;
        }

        [HttpPost("alocar")]
        public async Task<IActionResult> Alocar([FromBody] RecursoFuncionarioDto rfDto)
        {
            var retorno = await _recursoFuncionarioService.AlocarRecurso(rfDto);
            if (retorno == null)
            {
                return Conflict(retorno);
            }
            return Ok(retorno);
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            var todos = await _recursoFuncionarioService.GetAll();
            if (!todos.Any())
            {
                return NoContent();
            }
            return Ok(todos);
        }

        [HttpGet("byRecurso")]
        public async Task<IActionResult> GetPorRecurso([FromBody] RecursoDto dto)
        {
            var total = await _recursoFuncionarioService.GetAlocoesPorRecurso(dto);
            return Ok(total);
        }

        [HttpGet("byDate")]
        public async Task<IActionResult> GetByDate([FromBody] DateTime start,[FromBody] DateTime end)
        {
            var lista = await _recursoFuncionarioService.GetByDate(start, end);
            if (!lista.Any())
            {
                return NoContent();
            }
            return Ok(lista);
        }
    }
}