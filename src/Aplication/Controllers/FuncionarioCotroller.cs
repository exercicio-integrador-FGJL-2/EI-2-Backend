using Microsoft.AspNetCore.Mvc;
using src.Application.Dtos;
using src.Domain.Services.Interface;

namespace src.Application.Controllers
{
    [Route("api/[controller]")]
    public class FuncionarioController : Controller
    {
        private readonly IFuncionarioService _funcionarioService;
        public FuncionarioController(IFuncionarioService funcionarioService)
        {
            _funcionarioService = funcionarioService;
        }

        [HttpGet]
        [Route("all")]
        public async Task<IActionResult> GetAll()
        {
            var funcionarios = await _funcionarioService.GetAllFuncionarios();
            if (!funcionarios.Any())
            {
                return NoContent();
            }
            return Ok(await _funcionarioService.GetAllFuncionarios());
        }
    }
}