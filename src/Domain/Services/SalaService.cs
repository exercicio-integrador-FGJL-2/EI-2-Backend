using src.Application.Dtos;
using src.Domain.Model;
using src.Domain.Services.Interface;
using src.Persistence.Repositories.Interfaces;

namespace src.Domain.Services
{
    public class SalaService : ISalaService
    {
        private readonly ISalaRepository _salaRepo;
        public SalaService(ISalaRepository salaRepo)
        {
            _salaRepo = salaRepo;
        }
        public async Task<IEnumerable<SalaDto>> GetAllSalas()
        {
            var salas = await _salaRepo.GetAllAsync();
            return salas.Select(s => new SalaDto(s.Id, s.Numero,s.Lugares,s.TemProjetor));
        }

        public async Task<SalaDto?> GetSalaById(long id)
        {
            var sala = await _salaRepo.GetByIdAsync(id);
            if (sala == null)
            {
                throw new NullReferenceException();
            }
            return new SalaDto(sala.Id, sala.Numero, sala.Lugares, sala.TemProjetor);
        }

        public async Task UpdateSala(SalaDto salaDto)
        {
            var lab = new Sala()
            {
                Id = salaDto.Id,
                Numero = salaDto.Numero,
                Lugares = salaDto.Lugares,
                TemProjetor = salaDto.Projetor
            }; 
            await _salaRepo.UpdateAsync(lab);
        }
    }
}