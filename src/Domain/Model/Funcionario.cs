using src.Domain.Model.Interface;

namespace src.Domain.Model
{
    public class Funcionario
    {
        public required long Id { get; set; }
        public required long Matricula { get; set; }
        public required string Nome { get; set; }
        public string? Cargo { get; set; }
        //Data de admissao do funcionario
        public required DateTime DAdmissao { get; set; }
        public List<Recurso> RecursosAlocados { get; set; } = new List<Recurso>();
    }
}