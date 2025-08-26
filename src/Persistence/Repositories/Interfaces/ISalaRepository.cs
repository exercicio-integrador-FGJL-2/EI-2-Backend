using src.Domain.Model;

namespace src.Persistence.Repositories.Interfaces
{
    public interface ISalaRepository
    {
        Task<Sala?> GetByIdAsync(long id);
        Task<IEnumerable<Sala>> GetAllAsync();
        Task UpdateAsync(Sala sala);
    }
}
