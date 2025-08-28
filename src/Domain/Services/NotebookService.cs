using src.Application.Dtos;
using src.Domain.Services.Interface;
using src.Persistence.Repositories.Interfaces;
using src.Domain.Model;

namespace src.Domain.Services
{
    public class NotebookService : INotebookService
    {
        private readonly INotebookRepository _notebookRepository;
        public NotebookService(INotebookRepository notebookRepository)
        {
            _notebookRepository = notebookRepository;
        }

        public async Task CreateNotebook(NotebookCreateDto notebookCreateDto)
        {
            await _notebookRepository.SaveAsync(new Notebook { DAquisicao = notebookCreateDto.DataAquisicao,
                                                                    Descricao = notebookCreateDto.Descricao ?? "",
                                                                    NroPatrimonio = notebookCreateDto.NroPatrimonio });
        }

        public async Task DeleteNotebook(long id)
        {
            var notebook = await _notebookRepository.GetByIdAsync(id);
            if (notebook == null)
            {
                throw new NullReferenceException();
            }
            await _notebookRepository.DeleteAsync(notebook);
        }

        public async Task<IEnumerable<NotebookDto>> GetAllNotebooks()
        {
            var notebooks = await _notebookRepository.GetAllAsync();
            return notebooks.Select(n => new NotebookDto (n.Id, n.NroPatrimonio, n.DAquisicao, n.Descricao));
        }

        public async Task<NotebookDto?> GetNotebookById(long id)
        {
            var note = await _notebookRepository.GetByIdAsync(id);
            if (note == null)
            {
                throw new NullReferenceException();
            }
            return new NotebookDto(note.Id, note.NroPatrimonio, note.DAquisicao, note.Descricao);

        }

        public async Task UpdateNotebook(NotebookDto dto)
        {
            await _notebookRepository.UpdateAsync(new Notebook { Id = dto.Id, NroPatrimonio = dto.NroPatrimonio, DAquisicao = dto.DataAquisicao, Descricao = dto.Descricao });
        }
    }
}