using Microsoft.AspNetCore.Components;
using src.Application.Dtos;
using src.Domain.Model;
using src.Domain.Services.Interface;
using src.Persistence.Repositories.Interfaces;
namespace tests.ServicesTests;

public class NotebookServiceTest
{
    private NotebookCreateDto _notebook;
    private readonly INotebookService _noteservice;
    [OneTimeSetUp]
    public void Setup()
    {
        _notebook = new NotebookCreateDto(123123, DateTime.Now, "blablabla");
    }

    [Test]
    public void CreateNotebook_ShouldChangeTheDb()
    {
        var lista = _noteservice.GetAllNotebooks(); 
        _noteservice.CreateNotebook(_notebook);

    }
}
