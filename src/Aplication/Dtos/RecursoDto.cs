namespace src.Application.Dtos;
public record RecursoDto(long Id, TipoRecursoDto TipoRecursoDto);
public enum TipoRecursoDto
{
    Sala, Laboratorio, Notebook
}