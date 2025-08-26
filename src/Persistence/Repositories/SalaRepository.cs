using Microsoft.EntityFrameworkCore;
using src.Domain.Model;
using src.Persistence.Repositories.Interfaces;

namespace src.Persistence.Repositories
{
    public class SalaRepository : ISalaRepository
    {   
       private readonly EmpresaContext _empresaContext;

        public SalaRepository(EmpresaContext empresaContext)
        {
            _empresaContext = empresaContext;
        }
        public async Task<IEnumerable<Sala>> GetAllAsync()
        {
            return await _empresaContext.Salas.ToListAsync();
        }

        public async Task<Sala?> GetByIdAsync(long id)
        {
            return await _empresaContext.Salas.FindAsync(id).AsTask();
        }

        public async Task UpdateAsync(Sala sala)
        {
            _empresaContext.Update(sala);
            await _empresaContext.SaveChangesAsync();
        }
    }
}
