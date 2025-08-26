using src.Domain.Model.Interface;

namespace src.Domain.Model
{
    public class Notebook : Recurso
    {
        // Data de aquisicao do notebook
        public required DateTime DAquisicao { get; set; }
        public required string Descricao { get; set; } 
        
    }
}