using src.Domain.Model;
using src.Domain.Model.Interface;

namespace src.Persistence.Repositories.Interfaces
{
    public interface IRecursoFuncionarioRepository
    {
        Task<List<RecursoFuncionario>> GetAllGroupedByDateAsync(); //group by date
        Task<int> GetAlocacoesPorRecurso(Recurso tipo);
        Task<List<RecursoFuncionario>> GetByDateAsync(DateTime start, DateTime end);
        Task AlocarAsync(RecursoFuncionario recursoFuncionario);


    }
}