using System.ComponentModel.DataAnnotations;
using src.Domain.Model.Interface;

namespace src.Domain.Model
{
    public class RecursoFuncionario
    {
        [Key]
        public Funcionario? Funcionario { get; set; }
        [Key]
        public Recurso? Recurso { get; set; }
        [Key]
        public required DateTime DataDeAlocacao { get; set; }

            


    }
}