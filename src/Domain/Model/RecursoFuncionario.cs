using System.ComponentModel.DataAnnotations;
using src.Domain.Model.Interface;

namespace src.Domain.Model
{
    public class RecursoFuncionario
    {
        [Key]
        public required Funcionario Funcionario { get; set; }
        [Key]
        public required Recurso Recurso { get; set; }
        [Key]
        public required DateTime DataDeAlocacao { get; set; }

    }
}