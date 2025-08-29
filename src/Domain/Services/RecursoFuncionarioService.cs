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
        public async Task<RecursoFuncionarioDto?> AlocarRecurso(RecursoFuncionarioDto rfDto)
        {
            RecursoFuncionario rf = new RecursoFuncionario { FuncionarioId = rfDto.IdFuncionario, RecursoId = rfDto.IdRecurso, DataDeAlocacao = rfDto.Data };
            Recurso? tipo = _decide.DecideTipo(rfDto.TipoRecursoDto);
            if (await _recursoFuncionarioRepo.FoiAlocado(rf))
            {
                return null;
            }
            var alocacoesDoDia = await  _recursoFuncionarioRepo.AlocadosNoDia(rf);
            if (alocacoesDoDia.Any())
            {
                if (alocacoesDoDia.Select(al => al.Recurso!.GetType() == tipo.GetType()).Any())
                {
                    return null;
                }
                if (rfDto.TipoRecursoDto == TipoRecursoDto.Laboratorio && alocacoesDoDia.Select(al => al.Recurso!.GetType() == new Sala().GetType()).Any())
                {
                    return null;
                }
                if (rfDto.TipoRecursoDto == TipoRecursoDto.Sala && alocacoesDoDia.Select(al => al.Recurso!.GetType() == new Laboratorio().GetType()).Any())
                {
                    return null;
                }
                
            }
            var response = await _recursoFuncionarioRepo.AlocarAsync(rf);
            return new RecursoFuncionarioDto(response.FuncionarioId, response.RecursoId, response.DataDeAlocacao.Date, response.Recurso switch
            {
                Sala => TipoRecursoDto.Sala,
                Notebook => TipoRecursoDto.Notebook,
                Laboratorio => TipoRecursoDto.Laboratorio,
                _ => throw new NullReferenceException()
            });
        }

        public async Task<IEnumerable<RecursoFuncionarioDto>> GetAll()
        {
            var rfs = await _recursoFuncionarioRepo.GetAllGroupedByDateAsync() ?? throw new NullReferenceException("Lista esta vazia.");
            var listaConvertida = rfs.Select(rf => new RecursoFuncionarioDto(
                rf.FuncionarioId,
                rf.RecursoId,
                rf.DataDeAlocacao,
                rf.Recurso switch
                {
                    Sala => TipoRecursoDto.Sala,
                    Laboratorio => TipoRecursoDto.Laboratorio,
                    Notebook => TipoRecursoDto.Notebook,
                    _ => throw new InvalidOperationException("Tipo de recurso desconhecido")
                }));
            return listaConvertida;
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