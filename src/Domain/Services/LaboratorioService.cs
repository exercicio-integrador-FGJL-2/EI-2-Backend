using src.Application.Dtos;
using src.Domain.Services.Interface;
using src.Domain.Model;
using src.Persistence.Repositories.Interfaces;


namespace src.Domain.Services
{
    public class LaboratorioService : ILaboratorioService
    {
        private readonly ILaboratorioRepository _labRepo;
        public LaboratorioService(ILaboratorioRepository labRepo)
        {
            _labRepo = labRepo;
        }
        public async Task<IEnumerable<LaboratorioDto>> GetAllLaboratorios()
        {
            var labs = await _labRepo.GetAllAsync();
            return labs.Select(l => new LaboratorioDto(l.Id, l.Nome, l.QComp, l.Descricao));
        }

        public async Task<LaboratorioDto?> GetLaboratorioById(long id)
        {
            var lab = await _labRepo.GetByIdAsync(id);
            if (lab == null)
            {
                throw new NullReferenceException();
            }
            return new LaboratorioDto(lab.Id, lab.Nome, lab.QComp, lab.Descricao);
        }

        public async Task UpdateLaboratorio(LaboratorioDto laboratorioDto)
        {
            var lab = new Laboratorio()
            {
                Id = laboratorioDto.Id,
                Nome = laboratorioDto.Nome,
                Descricao = laboratorioDto.Descricao ?? "",
                QComp = laboratorioDto.QComp,
            }; 
            await _labRepo.UpdateAsync(lab);
        }
    }
}