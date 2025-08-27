using src.Application.Dtos;

namespace src.Domain.Services.Interface
{
    public interface INotebookService
    {
        Task<NotebookResponseDto?> GetNotebookById(long id);
        Task<IEnumerable<NotebookResponseDto>> GetAllNotebooks();
        Task CreateNotebook(NotebookCreateDto notebookCreateDto);
        Task DeleteNotebook(long id);
    }
}