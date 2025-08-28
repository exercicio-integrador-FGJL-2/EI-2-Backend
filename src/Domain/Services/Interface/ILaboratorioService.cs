using src.Application.Dtos;

namespace src.Domain.Services.Interface
{
    public interface ILaboratorioService
    {
        Task<IEnumerable<LaboratorioDto>> GetAllLaboratorios();
        Task UpdateLaboratorio(LaboratorioDto laboratorioDto);
        Task<LaboratorioDto?> GetLaboratorioById(long id);
    }
}