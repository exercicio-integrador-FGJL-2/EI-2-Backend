using System.ComponentModel.DataAnnotations;
using src.Domain.Model.Interface;

namespace src.Domain.Model
{
    public class Funcionario
    {
        public long Id { get; set; }
        public required long Matricula { get; set; }
        [MaxLength(100)]
        public required string Nome { get; set; }
        [MaxLength(50)]
        public string? Cargo { get; set; }
        //Data de admissao do funcionario
        public required DateTime DAdmissao { get; set; }
        public List<Recurso> RecursosAlocados { get; set; } = new List<Recurso>();
    }
}