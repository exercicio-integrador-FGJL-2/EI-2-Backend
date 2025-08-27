using src.Application.Dtos;

namespace src.Domain.Services.Interface
{
    public interface IFuncionarioService
    {
        Task<IEnumerable<FuncionarioDto>> GetAllFuncionarios();
    }
}