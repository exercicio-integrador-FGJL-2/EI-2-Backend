using src.Domain.Model.Interface;

namespace src.Domain.Model
{
    public class Laboratorio : IRecurso
    {
        public long Id { get; set; }

        public required string Nome { get; set; }

        // Quantos computadores esse laboratorio possui.
        public required int QComp { get; set; }
        
        public required string Descricao { get; set; }

    }
}