namespace src.Application.Dtos;

public record SalaResponseDto(long Id, int Numero, int Lugares, bool Projetor, string? Descricao, List<FuncionarioDto> FuncionarioDtos);
