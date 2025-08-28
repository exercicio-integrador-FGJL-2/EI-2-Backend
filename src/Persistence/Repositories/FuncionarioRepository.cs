
using Microsoft.EntityFrameworkCore;
using src.Domain.Model;
using src.Persistence.Repositories.Interfaces;

namespace src.Persistence.Repositories
{
    public class FuncionarioRepository : IFuncionarioRepository
    {
        private readonly EmpresaContext _empresaContext;

        public FuncionarioRepository(EmpresaContext empresaContext)
        {
            _empresaContext = empresaContext;
        }
        public async Task<List<Funcionario>> GetAllAsync()
        {
            var lista = await _empresaContext.Funcionarios.ToListAsync();
            
            return lista;
        }

    }

}