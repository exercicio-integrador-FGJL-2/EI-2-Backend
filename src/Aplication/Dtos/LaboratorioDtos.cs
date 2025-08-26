namespace src.Application.Dtos;

public record LaboratorioResponseDto(long Id, string Nome, int QtdComputadores, string ConfigComputadores, string? Descricao);
public record LaboratorioUpdateDto(string Nome, int QtdComputadores, string ConfigComputadores, string? Descricao);
