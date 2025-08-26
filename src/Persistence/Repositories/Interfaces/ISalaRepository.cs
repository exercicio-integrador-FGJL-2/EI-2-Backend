using src.Domain.Model;

namespace src.Persistence.Repositories.Interfaces
{
    public interface ISalaRepository : IGenericRepository<Sala>
    {
        Task<Sala?> GetByNumeroAsync(int numero, CancellationToken ct = default);
        Task<bool> NumeroExistsAsync(int numero, long? exceptId = null, CancellationToken ct = default);
    }
}
