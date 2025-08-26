namespace src.Domain.Model.Interface
{
    public abstract class Recurso
    {
        public long Id { get; set; }
        public List<Funcionario> Funcionarios { get; set; } = new List<Funcionario>();// Funcionarios que alocaram recursos.
    }
}