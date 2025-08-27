namespace src.Application.Dtos;

public record NotebookResponseDto(long Id, long NroPatrimonio, DateTime DataAquisicao, string? Descricao, List<FuncionarioDto> FuncionarioDtos);
public record NotebookCreateDto(long NroPatrimonio, DateTime DataAquisicao, string? Descricao);
