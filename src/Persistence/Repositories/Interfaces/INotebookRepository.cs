using src.Domain.Model;

namespace src.Persistence.Repositories.Interfaces;

public interface INotebookRepository
{
    Task<Notebook?> GetByIdAsync(long id);
    Task<IEnumerable<Notebook>> GetAllAsync();
    Task SaveAsync(Notebook notebook);
    Task UpdateAsync(Notebook notebook);
    Task DeleteAsync(Notebook notebook);
}
