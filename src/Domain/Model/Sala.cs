using System.ComponentModel.DataAnnotations;
using src.Domain.Model.Interface;

namespace src.Domain.Model
{
    public class Sala : Recurso
    {
        public  int Numero { get; set; }
        public  int Lugares { get; set; }
        public  bool TemProjetor { get; set; }
        

    }
    
    
}