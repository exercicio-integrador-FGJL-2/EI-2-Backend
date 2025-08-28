using System.ComponentModel.DataAnnotations;
using src.Domain.Model.Interface;

namespace src.Domain.Model
{
    public class Funcionario
    {
        public long Id { get; set; }
        public long Matricula { get; set; }
        [MaxLength(100)]
        public string? Nome { get; set; }
        [MaxLength(50)]
        public string? Cargo { get; set; }
        //Data de admissao do funcionario
        public  DateTime DAdmissao { get; set; }
        public List<RecursoFuncionario> RecursoFuncionarios { get; set; } = new List<RecursoFuncionario>();
    }
}