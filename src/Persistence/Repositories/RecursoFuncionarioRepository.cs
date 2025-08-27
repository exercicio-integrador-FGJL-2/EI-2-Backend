using Microsoft.EntityFrameworkCore;
using src.Domain.Model;
using src.Domain.Model.Interface;
using src.Persistence.Repositories.Interfaces;

namespace src.Persistence.Repositories
{
    public class RecursoFuncionarioRepository : IRecursoFuncionarioRepository
    {
        private readonly EmpresaContext _empresaContext;
        public RecursoFuncionarioRepository(EmpresaContext empresaContext)
        {
            _empresaContext = empresaContext;
        }

        public Task<List<RecursoFuncionario>> GetAllGroupedByDateAsync()
        {
            throw new NotImplementedException();
        }

        public Task<int?> GetAlocacoesPorRecurso(Recurso r)
        {
            throw new NotImplementedException();
        }

        public Task<List<RecursoFuncionario>> GetByDateAsync(DateTime start, DateTime end)
        {
            throw new NotImplementedException();
        }
    }
}