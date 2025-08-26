using src.Domain.Model.Interface;

namespace src.Domain.Model
{
    public class Sala : IRecurso
    {
        public long Id { get; set; }
        public required int Numero { get; set; }
        public required int Lugares { get; set; }
        public required bool TemProjetor { get; set; }
        public List<Funcionario> Funcionarios { get; set; } = new List<Funcionario>();

    }
    
}