using Microsoft.EntityFrameworkCore;
using src.Domain.Model;
using src.Persistence.Repositories.Interfaces;

namespace src.Persistence.Repositories;

public class LaboratorioRepository : GenericRepository<Laboratorio>, ILaboratorioRepository
{
    private readonly AppDbContext _app;

    public LaboratorioRepository(AppDbContext ctx) : base(ctx) => _app = ctx;

    public Task<Laboratorio?> GetByNomeAsync(string nome, CancellationToken ct = default)
        => _app.Laboratorios.AsNoTracking().FirstOrDefaultAsync(l => l.Nome == nome, ct);
}
