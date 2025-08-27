using Microsoft.EntityFrameworkCore;
using src.Domain.Model;
using src.Persistence.Repositories.Interfaces;

namespace src.Persistence.Repositories;

public class NotebookRepository : INotebookRepository
{
    private readonly EmpresaContext _empresaContext;

    public NotebookRepository(EmpresaContext empresaContext)
    {
        _empresaContext = empresaContext;
    }
    public async Task<IEnumerable<Notebook>> GetAllAsync()
    {
        return await _empresaContext.Notebooks.ToListAsync();
    }

    public Task<Notebook?> GetByIdAsync(long id)
    {
        return _empresaContext.Notebooks.FindAsync(id).AsTask();
    }

    public async Task SaveAsync(Notebook notebook)
    {
        await _empresaContext.AddAsync(notebook);
        await _empresaContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(Notebook notebook)
    {
        _empresaContext.Update(notebook);
        await _empresaContext.SaveChangesAsync();
    }
    public async Task DeleteAsync(Notebook n)
    {
        _empresaContext.Notebooks.Remove(n);
        await _empresaContext.SaveChangesAsync();
    }
}
