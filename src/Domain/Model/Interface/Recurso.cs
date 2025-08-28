namespace src.Domain.Model.Interface
{
    public abstract class Recurso
    {
        public long Id { get; set; }
        public List<RecursoFuncionario> RecursoFuncionarios { get; set; } = new List<RecursoFuncionario>();// Funcionarios que alocaram recursos.
    }
}