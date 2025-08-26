using src.Domain.Model;

namespace src.Persistence.Repositories.Interfaces;

public interface INotebookRepository : IGenericRepository<Notebook>
{
    // Exemplo: buscar por patrimônio
    Task<Notebook?> GetByPatrimonioAsync(string patrimonio, CancellationToken ct = default);
}
