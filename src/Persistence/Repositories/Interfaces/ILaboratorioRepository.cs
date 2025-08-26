using src.Domain.Model;

namespace src.Persistence.Repositories.Interfaces;

public interface ILaboratorioRepository
{
    Task<Laboratorio?> GetByIdAsync(long id);
    Task<IEnumerable<Laboratorio>> GetAllAsync();
    Task UpdateAsync(Laboratorio lab);
}
