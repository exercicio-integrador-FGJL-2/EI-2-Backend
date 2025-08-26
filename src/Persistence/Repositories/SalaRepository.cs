using src.Domain.Model;
using src.Persistence.Repositories.Interfaces;

namespace src.Persistence.Repositories
{
    public class SalaRepository : ISalaRepository
    {   
        public Task<Sala> GetByIdAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateSalaAsync(Sala s)
        {
            throw new NotImplementedException();
        }
    }
}