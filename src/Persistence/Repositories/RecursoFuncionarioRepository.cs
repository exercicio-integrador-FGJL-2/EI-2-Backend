using Microsoft.EntityFrameworkCore;
using src.Application.Dtos;
using src.Domain.Model;
using src.Domain.Model.Interface;
using src.Persistence.Repositories.Interfaces;

namespace src.Persistence.Repositories
{
    public class RecursoFuncionarioRepository : IRecursoFuncionarioRepository
    {
        private readonly EmpresaContext _empresaContext;
        public RecursoFuncionarioRepository(EmpresaContext empresaContext)
        {
            _empresaContext = empresaContext;
        }

        public async Task<IEnumerable<RecursoFuncionario>> AlocadosNoDia(RecursoFuncionario rfEntrada)
        {
            return await _empresaContext.RecursoFuncionarios.Where(rf => rf.FuncionarioId == rfEntrada.FuncionarioId && rf.DataDeAlocacao.Date == rfEntrada.DataDeAlocacao.Date).ToListAsync();
            
        }

        public async Task<RecursoFuncionario> AlocarAsync(RecursoFuncionario recursoFuncionario)
        {
            await _empresaContext.RecursoFuncionarios.AddAsync(recursoFuncionario);
            await _empresaContext.SaveChangesAsync();
            return recursoFuncionario;
        }

        public async Task<bool> FoiAlocado(RecursoFuncionario recurso)
        {
            bool alocado = await _empresaContext.RecursoFuncionarios.Select(rf => rf.DataDeAlocacao.Date == recurso.DataDeAlocacao.Date).AnyAsync();
            System.Console.WriteLine("foi alocado: " + alocado);
            return alocado;
        }

        public async Task<List<RecursoFuncionario>> GetAllGroupedByDateAsync()
        {

            var recursosFuncionarios = await _empresaContext.RecursoFuncionarios
                                                            .Include(rf => rf.Funcionario)
                                                            .Include(rf =>rf.Recurso)
                                                            .ToListAsync();
            
            return recursosFuncionarios;
        }

        public async Task<int> GetAlocacoesPorRecurso(Recurso r)
        {
            var tipo = r.GetType();
            var list = await _empresaContext.RecursoFuncionarios
                                .Include(rf => rf.Recurso)
                                .ToListAsync();
            
            

            return list.Count(rf => rf.Recurso.GetType() == tipo);
        }

        public async Task<List<RecursoFuncionario>> GetByDateAsync(DateTime start, DateTime end)
        {
            return await _empresaContext.RecursoFuncionarios
                                        .Where(rf => rf.DataDeAlocacao >= start && rf.DataDeAlocacao <= end)
                                        .ToListAsync();
        }
    }
}