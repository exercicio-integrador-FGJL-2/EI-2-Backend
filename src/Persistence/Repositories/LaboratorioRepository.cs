using Microsoft.EntityFrameworkCore;
using src.Domain.Model;
using src.Persistence.Repositories.Interfaces;

namespace src.Persistence.Repositories;

public class LaboratorioRepository : ILaboratorioRepository
{

    private readonly EmpresaContext _empresaContext;

    public LaboratorioRepository(EmpresaContext empresaContext)
    {
        _empresaContext = empresaContext;
    }
    public async Task<IEnumerable<Laboratorio>> GetAllAsync()
    {
        return  await _empresaContext.Laboratorios.ToListAsync();
    }

    public async Task<Laboratorio?> GetByIdAsync(long id)
    {
        return await _empresaContext.Laboratorios.FindAsync(id);
    }

    public async Task UpdateAsync(Laboratorio lab)
    {
        _empresaContext.Update(lab);
        await _empresaContext.SaveChangesAsync();
    }
}
