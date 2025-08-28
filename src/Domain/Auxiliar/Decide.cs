using src.Application.Dtos;
using src.Domain.Auxiliar.Interface;
using src.Domain.Model;
using src.Domain.Model.Interface;

public class Decide : IDecide
{
    public Recurso DecideTipo(TipoRecursoDto tipo)
    {
        if (tipo == TipoRecursoDto.Sala)
        {
            return new Sala();
        }
        else if (tipo == TipoRecursoDto.Laboratorio)
        {
            return new Laboratorio();
        }
        return new Notebook();
    }
}