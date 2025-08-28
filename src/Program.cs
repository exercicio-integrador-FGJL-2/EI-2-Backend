
using Microsoft.EntityFrameworkCore;
using src.Domain.Auxiliar.Interface;
using src.Domain.Services;
using src.Domain.Services.Interface;
using src.Persistence.Repositories;
using src.Persistence.Repositories.Interfaces;

namespace src;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddScoped<IFuncionarioService, FuncionarioService>();
        builder.Services.AddScoped<IFuncionarioRepository, FuncionarioRepository>();
        builder.Services.AddSingleton<IDecide, Decide>();

        builder.Services.AddControllers();
        // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
        builder.Services.AddOpenApi();

        builder.Services.AddDbContext<EmpresaContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

       

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
        }



        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}
