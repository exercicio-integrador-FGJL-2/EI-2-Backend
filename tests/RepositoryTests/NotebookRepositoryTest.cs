using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using src.Application.Dtos;
using src.Domain.Model;
using src.Persistence.Repositories;
using src.Persistence.Repositories.Interfaces;
namespace tests.ServicesTests;

public class NotebookRepositoryTest
{
    private Notebook _notebook;
    private INotebookRepository _noterepo;
    [OneTimeSetUp]
    public void Setup()
    {
        _notebook = new Notebook { NroPatrimonio = 123123, DAquisicao = DateTime.Now, Descricao = "blablabla" };
        var options = new DbContextOptionsBuilder<EmpresaContext>()
                          .UseInMemoryDatabase(databaseName: "testDb")
                          .Options;
        _noterepo = new NotebookRepository(new EmpresaContext(options));
    }


    [Test]
    [Order(1)]

    public async Task CreateNotebook_NoteTableShouldNotBeEmpty()
    {
        await _noterepo.SaveAsync(_notebook);
        var table = await _noterepo.GetAllAsync();
        Assert.That(!table.IsNullOrEmpty());
    }


    [Test]
    [TestCase(1)]
    [Order(2)]

    public async Task GetNotebookBtId_ShouldReturnANotebook(int id)
    {
        var note = await _noterepo.GetByIdAsync(id);
        Assert.That(note, Is.Not.EqualTo(null));
    }

    [Test]
    [Order(3)]

    public async Task UpdateAsync_ShouldChangeTheContent()
    {
        string oldDescription = _notebook.Descricao;
        _notebook.Descricao = "nova descricao";
        await _noterepo.UpdateAsync(_notebook);
        var newNote = await _noterepo.GetByIdAsync(1);
        Assert.That(newNote!.Descricao, Is.Not.EqualTo(oldDescription));
    }

    [Test]
    [Order(4)]
    public async Task DeleteAsync_ShouldDeleteProperly()
    {
        await _noterepo.DeleteAsync(_notebook);
        var lista = await _noterepo.GetAllAsync();
        Assert.That(lista, Is.Empty);
    }
}
