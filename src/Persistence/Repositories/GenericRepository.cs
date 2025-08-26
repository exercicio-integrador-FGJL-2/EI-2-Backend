using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using src.Persistence.Repositories.Interfaces;

namespace src.Persistence.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly DbContext _ctx;
        protected readonly DbSet<T> _db;

        public GenericRepository(DbContext ctx)
        {
            _ctx = ctx;
            _db = _ctx.Set<T>();
        }

        public virtual async Task<T?> GetByIdAsync(long id, CancellationToken ct = default)
            => await _db.FindAsync(new object?[] { id }, ct);

        public virtual async Task<IReadOnlyList<T>> GetAllAsync(CancellationToken ct = default)
            => await _db.AsNoTracking().ToListAsync(ct);

        public virtual async Task<IReadOnlyList<T>> FindAsync(Expression<Func<T,bool>> predicate, CancellationToken ct = default)
            => await _db.AsNoTracking().Where(predicate).ToListAsync(ct);

        public virtual async Task AddAsync(T entity, CancellationToken ct = default)
            => await _db.AddAsync(entity, ct);

        public virtual void Update(T entity) => _db.Update(entity);
        public virtual void Remove(T entity) => _db.Remove(entity);
        public Task<int> SaveChangesAsync(CancellationToken ct = default) => _ctx.SaveChangesAsync(ct);
        public Task<bool> ExistsAsync(Expression<Func<T,bool>> predicate, CancellationToken ct = default)
            => _db.AnyAsync(predicate, ct);
    }
}
