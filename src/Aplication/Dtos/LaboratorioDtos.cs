using src.Domain.Model;

namespace src.Application.Dtos;

public record LaboratorioDto(long Id, string Nome, int QComp, string? Descricao);
