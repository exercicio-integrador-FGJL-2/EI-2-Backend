namespace src.Application.Dtos;

public record FuncionarioResponseDto( long Matricula, string Nome, string? Cargo, DateTime DAdmissao );
public record FuncionarioUpdateDto( string Nome, string? Cargo, Datetime DAdmissao );