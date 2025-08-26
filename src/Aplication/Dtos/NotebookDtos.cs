namespace src.Application.Dtos;

public record NotebookResponseDto(long Id, string NroPatrimonio, DateTime DataAquisicao, string? Descricao);
public record NotebookCreateDto(string NroPatrimonio, DateTime DataAquisicao, string? Descricao);
public record NotebookUpdateDto(string NroPatrimonio, DateTime DataAquisicao, string? Descricao);
