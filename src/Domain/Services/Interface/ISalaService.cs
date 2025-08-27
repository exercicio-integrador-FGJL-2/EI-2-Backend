using src.Application.Dtos;

namespace src.Domain.Services.Interface
{
    public interface ISalaService
    {
        Task<IEnumerable<SalaDto>> GetAllSalas();
        Task UpdateSala(SalaDto salaDto);
        Task<SalaDto?> GetSalaById(long id);
    }
}