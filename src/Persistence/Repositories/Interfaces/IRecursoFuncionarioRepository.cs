using src.Domain.Model;
using src.Domain.Model.Interface;

namespace src.Persistence.Repositories.Interfaces
{
    public interface IRecursoFuncionarioRepository
    {
        Task<List<RecursoFuncionario>> GetAllGroupedByDateAsync(); //group by date
        Task<int> GetAlocacoesPorRecurso(Recurso r);
        Task<List<RecursoFuncionario>> GetByDateAsync(DateTime start, DateTime end);
        Task<RecursoFuncionario> AlocarAsync(RecursoFuncionario recursoFuncionario);

        Task<bool> FoiAlocado(RecursoFuncionario recurso);
        Task<IEnumerable<RecursoFuncionario>> AlocadosNoDia(RecursoFuncionario rf);
    }
}