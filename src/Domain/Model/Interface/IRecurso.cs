namespace src.Domain.Model.Interface
{
    public interface IRecurso
    {
        public long Id { get; set; }
        public List<Funcionario> Funcionarios { get; set; } // Funcionarios que alocaram recursos.
    }
}