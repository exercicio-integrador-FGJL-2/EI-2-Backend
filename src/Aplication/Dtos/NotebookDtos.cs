namespace src.Application.Dtos;

public record NotebookDto(long Id, long NroPatrimonio, DateTime DataAquisicao, string? Descricao);
public record NotebookCreateDto(long NroPatrimonio, DateTime DataAquisicao, string? Descricao);


