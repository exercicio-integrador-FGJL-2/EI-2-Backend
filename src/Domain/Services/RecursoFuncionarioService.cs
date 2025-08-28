using Microsoft.AspNetCore.Http.HttpResults;
using src.Application.Dtos;
using src.Domain.Auxiliar.Interface;
using src.Domain.Model;
using src.Domain.Model.Interface;
using src.Domain.Services.Interface;
using src.Persistence.Repositories.Interfaces;

namespace src.Domain.Services
{
    public class RecursoFuncionarioService : IRecursoFuncionarioService
    {
        private readonly IRecursoFuncionarioRepository _recursoFuncionarioRepo;
        private readonly IDecide _decide;

        public RecursoFuncionarioService(IRecursoFuncionarioRepository recursoFuncionarioRepository, IDecide decide)
        {
            _recursoFuncionarioRepo = recursoFuncionarioRepository;
            _decide = decide;
        }
        public async Task AlocarRecurso(RecursoFuncionarioDto rfDto)
        {
            var funcionario = new Funcionario { Id = rfDto.IdFuncionario };
            var rec = _decide.DecideTipo(rfDto.TipoRecursoDto);
            rec.Id = rfDto.IdRecurso;

            await _recursoFuncionarioRepo.AlocarAsync(new RecursoFuncionario { Funcionario = funcionario, Recurso = rec, DataDeAlocacao = rfDto.Data });
        }

        public async Task<IEnumerable<RecursoFuncionarioDto>> GetAll()
        {
            var rfs = await _recursoFuncionarioRepo.GetAllGroupedByDateAsync();
            return rfs.Select(rf => new RecursoFuncionarioDto(
                rf.Funcionario.Id,
                rf.Recurso.Id,
                rf.DataDeAlocacao,
                rf.Recurso switch
                {
                    Sala => TipoRecursoDto.Sala,
                    Laboratorio => TipoRecursoDto.Laboratorio,
                    Notebook => TipoRecursoDto.Notebook,
                    _ => throw new InvalidOperationException("Tipo de recurso desconhecido")
                }));
        }

        public async Task<int> GetAlocoesPorRecurso(RecursoDto recursoDto)
        {
            var tipo = _decide.DecideTipo(recursoDto.TipoRecursoDto);
            return await _recursoFuncionarioRepo.GetAlocacoesPorRecurso(tipo);
        }

        public async Task<IEnumerable<RecursoFuncionarioDto>> GetByDate(DateTime start, DateTime end)
        {
            var rfs = await _recursoFuncionarioRepo.GetByDateAsync(start,end);
            return rfs.Select(rf => new RecursoFuncionarioDto(
                rf.Funcionario.Id,
                rf.Recurso.Id,
                rf.DataDeAlocacao,
                rf.Recurso switch
                {
                    Sala => TipoRecursoDto.Sala,
                    Laboratorio => TipoRecursoDto.Laboratorio,
                    Notebook => TipoRecursoDto.Notebook,
                    _ => throw new InvalidOperationException("Tipo de recurso desconhecido")
                }));
        }
    }
}