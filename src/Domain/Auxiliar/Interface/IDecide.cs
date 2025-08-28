using src.Application.Dtos;
using src.Domain.Model.Interface;

namespace src.Domain.Auxiliar.Interface;
public interface IDecide
{
    Recurso DecideTipo(TipoRecursoDto tipo);
}