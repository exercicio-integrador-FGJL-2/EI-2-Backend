using src.Domain.Model.Interface;

namespace src.Domain.Model
{
    public class RecursoFuncionario
    {
        public required Funcionario Funcionario { get; set; }
        public required Recurso Recurso { get; set; }
        public required DateTime DataDeAlocacao { get; set; }

    }
}