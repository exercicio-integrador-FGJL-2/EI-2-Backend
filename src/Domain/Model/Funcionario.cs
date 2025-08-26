namespace src.Domain.Model
{
    public class Funcionario
    {
        public required long Matricula { get; set; }
        public required string Nome { get; set; }
        public string? Cargo { get; set; }
        //Data de admissao do funcionario
        public required DateTime DAdmissao { get; set; }
    }
}