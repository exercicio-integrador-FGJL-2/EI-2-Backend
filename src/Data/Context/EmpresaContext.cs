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
        modelBuilder.Entity<Recurso>()
        .ToTable("Recurso");
        modelBuilder.Entity<RecursoFuncionario>()
        .ToTable("FuncionarioRecurso");
    }
}