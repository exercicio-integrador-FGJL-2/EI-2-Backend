using src.Domain.Model;

namespace src.Persistence.Repositories.Interfaces;

public interface IFuncionarioRepository
{
    Task<List<Funcionario>> GetAllAsync();
}
