using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using src.Domain.Model.Interface;

namespace src.Domain.Model
{
    public class Laboratorio : Recurso
    {
        [MaxLength(100)]
        public required string Nome { get; set; }
        // Quantos computadores esse laboratorio possui.
        public required int QComp { get; set; }      
        [MaxLength(200)]
        public required string Descricao { get; set; }
    }
}