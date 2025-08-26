using Microsoft.EntityFrameworkCore;
using src.Domain.Model;
using src.Persistence.Repositories.Interfaces;

namespace src.Persistence.Repositories;

public class NotebookRepository : GenericRepository<Notebook>, INotebookRepository
{
    private readonly AppDbContext _app;

    public NotebookRepository(AppDbContext ctx) : base(ctx) => _app = ctx;

    public Task<Notebook?> GetByPatrimonioAsync(string patrimonio, CancellationToken ct = default)
        => _app.Notebooks.AsNoTracking().FirstOrDefaultAsync(n => n.NroPatrimonio == patrimonio, ct);
}
