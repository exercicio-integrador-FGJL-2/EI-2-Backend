using src.Domain.Model;

namespace src.Persistence.Repositories.Interfaces;

public interface ILaboratorioRepository : IGenericRepository<Laboratorio>
{
    // Exemplo: buscar por nome
    Task<Laboratorio?> GetByNomeAsync(string nome, CancellationToken ct = default);
}
