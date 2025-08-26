using src.Domain.Model;
namespace src.Persistence.Repositories.Interfaces
{
    public interface ISalaRepository
    {
        public Task<Sala> GetByIdAsync(long id);
        public Task<bool> UpdateSalaAsync(Sala s);
    }
}