using System.ComponentModel.DataAnnotations;
using src.Domain.Model.Interface;

namespace src.Domain.Model
{
    public class Sala : Recurso
    {
        public required int Numero { get; set; }
        public required int Lugares { get; set; }
        public required bool TemProjetor { get; set; }
        

    }
    
    
}