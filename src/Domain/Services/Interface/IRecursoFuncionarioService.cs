
using src.Application.Dtos;

namespace src.Domain.Services.Interface
{
    public interface IRecursoFuncionarioService
    {
        Task AlocarRecurso(RecursoFuncionarioDto rfDto);
        Task<IEnumerable<RecursoFuncionarioDto>> GetAll();
        Task<int> GetAlocoesPorRecurso(TipoRecursoDto tipoDto);
        Task<IEnumerable<RecursoFuncionarioDto>> GetByDate(DateTime start, DateTime end);
    }
}