using Microsoft.EntityFrameworkCore;
using src.Domain.Model;
using src.Persistence.Repositories;
using src.Persistence.Repositories.Interfaces;

namespace src.RepositoryTests
{
    public class SalaRepositoryTest
    {
        private Sala _sala;
        private ISalaRepository _salaRepo;
        [OneTimeSetUp]
        public void Setup()
        {
            this._sala = new Sala { Numero = 103, Lugares = 30, TemProjetor = true };
            var options = new DbContextOptionsBuilder<EmpresaContext>()
                          .UseInMemoryDatabase(databaseName: "testDbSala")
                          .Options;
            _salaRepo = new SalaRepository(new EmpresaContext(options));
        }

      
    }
}