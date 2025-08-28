using src.Application.Dtos;

namespace src.Domain.Services.Interface
{
    public interface INotebookService
    {
        Task<NotebookDto?> GetNotebookById(long id);
        Task<IEnumerable<NotebookDto>> GetAllNotebooks();
        Task CreateNotebook(NotebookCreateDto notebookCreateDto);
        Task DeleteNotebook(long id);
        Task UpdateNotebook(NotebookDto dto);
    }
}