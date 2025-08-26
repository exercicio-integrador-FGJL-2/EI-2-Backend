using src.Domain.Model.Interface;

namespace src.Domain.Model
{
    public class Notebook : IRecurso
    {
        public long Id { get; set; }

        // Data de aquisicao do notebook
        public required DateTime DAquisicao { get; set; }
        
        public required string Descricao{ get; set; } 
    }
}