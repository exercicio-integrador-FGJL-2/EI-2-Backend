using System.ComponentModel.DataAnnotations;
using src.Domain.Model.Interface;

namespace src.Domain.Model
{
    public class Notebook : Recurso
    {
        // Data de aquisicao do notebook
        public required DateTime DAquisicao { get; set; }
        [MaxLength(200)]
        public required string Descricao { get; set; } 
        
    }
}