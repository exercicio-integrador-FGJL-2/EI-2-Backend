using Microsoft.EntityFrameworkCore;
using src.Domain.Model;

public class EmpresaContext : DbContext
{
    public DbSet<Sala> Salas { get; set; }
    public DbSet<Laboratorio> Laboratorios { get; set; }
    public DbSet<Notebook> Notebooks { get; set; }
    public DbSet<Funcionario> Funcionarios { get; set; }

    public EmpresaContext(DbContextOptions options) : base(options)
    {
            
    }



}