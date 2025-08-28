using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using src.Domain.Model.Interface;

namespace src.Domain.Model
{
    public class Laboratorio : Recurso
    {
        [MaxLength(100)]
        public  string? Nome { get; set; }
        // Quantos computadores esse laboratorio possui.
        public  int QComp { get; set; }      
        [MaxLength(200)]
        public  string? Descricao { get; set; }
    }
}