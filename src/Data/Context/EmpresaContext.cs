using Microsoft.EntityFrameworkCore;
using src.Domain.Model;
using src.Domain.Model.Interface;

public class EmpresaContext : DbContext
{
    public DbSet<Sala> Salas { get; set; }
    public DbSet<Laboratorio> Laboratorios { get; set; }
    public DbSet<Notebook> Notebooks { get; set; }
    public DbSet<Funcionario> Funcionarios { get; set; }
    public DbSet<RecursoFuncionario> RecursoFuncionarios { get; set; }

    public EmpresaContext(DbContextOptions options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Recurso>()
        .ToTable("Recurso");
        modelBuilder.Entity<Laboratorio>()
        .ToTable("Laboratorio");
        modelBuilder.Entity<Sala>()
        .ToTable("Sala");

        modelBuilder.Entity<RecursoFuncionario>()
        .Property<long>("FuncionarioId");

        modelBuilder.Entity<RecursoFuncionario>()
        .Property<long>("RecursoId");

        modelBuilder.Entity<Funcionario>().HasData(
            new Funcionario { Id = 1, Matricula = 1234, Nome = "João do pão", Cargo = "Vendedor", DAdmissao = new DateTime(2000, 01, 30) },
            new Funcionario { Id = 2, Matricula = 1235, Nome = "José da Manga", Cargo = "Vendedor", DAdmissao = new DateTime(2000, 01, 30) },
            new Funcionario { Id = 3, Matricula = 1236, Nome = "Maria Madalena", Cargo = "Vendedor", DAdmissao = new DateTime(2000, 01, 30) }
        );



        modelBuilder.Entity<Sala>().HasData(
            new Sala { Id = 1, Lugares = 30, Numero = 104, TemProjetor = true }
        );

        modelBuilder.Entity<Laboratorio>().HasData(
            new Laboratorio { Id = 2, Nome = "Laboratório de computação gráfica", Descricao = "Laboratório destinado ao aprendizado de CG", QComp = 30 }
        );

        modelBuilder.Entity<Notebook>().HasData(
            new Notebook { Id = 3, NroPatrimonio = 1002, DAquisicao = new DateTime(2024, 10, 10), Descricao = "8 gb de ram, funciona, é da dell" }
        );

        modelBuilder.Entity<RecursoFuncionario>().HasData(
            new { FuncionarioId = 1L, DataDeAlocacao = new DateTime(2025, 08, 30), RecursoId = 2L }
        );

    }
}