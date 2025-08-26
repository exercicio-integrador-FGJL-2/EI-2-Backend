using Microsoft.EntityFrameworkCore;
using src.Domain.Model;
using src.Persistence.Repositories.Interfaces;

namespace src.Persistence.Repositories
{
    public class SalaRepository : GenericRepository<Sala>, ISalaRepository
    {
        private readonly AppDbContext _app;

        public SalaRepository(AppDbContext ctx) : base(ctx) => _app = ctx;

        public Task<Sala?> GetByNumeroAsync(int numero, CancellationToken ct = default)
            => _app.Salas.AsNoTracking().FirstOrDefaultAsync(s => s.Numero == numero, ct);

        public Task<bool> NumeroExistsAsync(int numero, long? exceptId = null, CancellationToken ct = default)
            => _app.Salas.AnyAsync(s => s.Numero == numero && (exceptId == null || s.Id != exceptId), ct);
    }
}
