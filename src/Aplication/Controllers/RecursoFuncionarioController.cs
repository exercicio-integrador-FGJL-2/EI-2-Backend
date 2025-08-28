using Microsoft.AspNetCore.Mvc;
using src.Application.Dtos;
using src.Domain.Services.Interface;

namespace src.Application.Controllers
{
    public class RecursoFuncionarioController : Controller
    {
        private readonly IRecursoFuncionarioService _recursoFuncionarioService;
        public RecursoFuncionarioController(IRecursoFuncionarioService recursoFuncionarioService)
        {
            _recursoFuncionarioService = recursoFuncionarioService;
        }


        public async Task<IActionResult> Alocar(RecursoFuncionarioDto rfDto)
        {
            await _recursoFuncionarioService.AlocarRecurso(rfDto);
            return Ok();
        }

        public async Task<IActionResult> GetAll()
        {
            var todos = await _recursoFuncionarioService.GetAll();
            if (!todos.Any())
            {
                return NoContent();
            }
            return Ok(todos);
        }

        public async Task<IActionResult> GetPorRecurso(RecursoDto dto)
        {
            var total = await _recursoFuncionarioService.GetAlocoesPorRecurso(dto);
            return Ok(total);
        }

        public async Task<IActionResult> GetByDate(DateTime start, DateTime end)
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