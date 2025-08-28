using Microsoft.EntityFrameworkCore;
using src.Domain.Model;
using src.Domain.Model.Interface;
using src.Persistence.Repositories;
using src.Persistence.Repositories.Interfaces;

namespace src.RepositoryTests;

public class RecursoFuncionarioRepoTest
{
    private RecursoFuncionario _rf;
    private IRecursoFuncionarioRepository _rfrepo;
    private Recurso _recurso;
    [OneTimeSetUp]
    public void Setup()
    {
        _recurso = new Notebook
        {
            NroPatrimonio = 123,
            DAquisicao = new DateTime(2024, 04, 29),
            Descricao = "bom notebook"
        };

        _rf = new RecursoFuncionario
        {
            Funcionario = new Funcionario
            {
                Matricula = 321321,
                Nome = "Joao feijão",
                DAdmissao = new DateTime(2000, 10, 12)
            },
            Recurso = _recurso,
            DataDeAlocacao = DateTime.Now
        };

        var options = new DbContextOptionsBuilder<EmpresaContext>()
                          .UseInMemoryDatabase(databaseName: "testDbRf")
                          .Options;

        _rfrepo = new RecursoFuncionarioRepository(new EmpresaContext(options));

    }
    [Test]
    [Order(1)]
    public async Task Alocar_ShouldWorkProperly()
    {
        await _rfrepo.AlocarAsync(_rf);
        var table = _rfrepo.GetAllGroupedByDateAsync();
        Assert.That(table, Is.Not.Null);
    }

    [Test]
    [Order(2)]
    public async Task GetAlocacoesPorRecurso_ShouldReturnOne()
    {
        int? count = await _rfrepo.GetAlocacoesPorRecurso(_recurso);
        Assert.That(count, Is.EqualTo(1));
    }
    [Test]
    [Order(3)]    
    public async Task GetAlocacoesPorRecurso_ShouldReturnZero()
    {
        int? count = await _rfrepo.GetAlocacoesPorRecurso(new Sala{Numero = 104, Lugares=40,TemProjetor=false});
        Assert.That(count, Is.EqualTo(0));
    }

    [Test]
    [Order(4)]
    public async Task GetAlocacoesPorData_ShouldReturnOneRow()
    {
        var response = await _rfrepo.GetByDateAsync(new DateTime(2000, 10, 20), new DateTime(2025, 10, 29));
        Assert.That(response, Is.Not.Empty);
        System.Console.WriteLine(response);
        
    }
}