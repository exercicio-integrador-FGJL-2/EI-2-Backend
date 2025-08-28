using System.Threading.Tasks;
using src.Application.Dtos;
using src.Domain.Services.Interface;
using src.Persistence.Repositories.Interfaces;

namespace src.Domain.Services
{
    public class FuncionarioService : IFuncionarioService
    {
        private readonly IFuncionarioRepository _funcionarioRepository;
        public FuncionarioService(IFuncionarioRepository funcionarioRepository)
        {
            _funcionarioRepository = funcionarioRepository;
        }
        public async Task<IEnumerable<FuncionarioDto>> GetAllFuncionarios()
        {
            var funcionarios = await _funcionarioRepository.GetAllAsync();
            if (funcionarios == null)
            {
                return [];
            }
            return funcionarios.Select(x => new FuncionarioDto(x.Matricula, x.Nome));
        }
    }
}