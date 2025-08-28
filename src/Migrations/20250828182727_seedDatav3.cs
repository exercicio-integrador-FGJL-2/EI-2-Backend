using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace src.Migrations
{
    /// <inheritdoc />
    public partial class seedDatav3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Funcionarios",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Matricula = table.Column<long>(type: "bigint", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Cargo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DAdmissao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Recurso",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recurso", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Laboratorio",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    QComp = table.Column<int>(type: "int", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Laboratorio", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Laboratorio_Recurso_Id",
                        column: x => x.Id,
                        principalTable: "Recurso",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Notebooks",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    NroPatrimonio = table.Column<long>(type: "bigint", nullable: false),
                    DAquisicao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notebooks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notebooks_Recurso_Id",
                        column: x => x.Id,
                        principalTable: "Recurso",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecursoFuncionarios",
                columns: table => new
                {
                    DataDeAlocacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FuncionarioId = table.Column<long>(type: "bigint", nullable: false),
                    RecursoId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecursoFuncionarios", x => new { x.DataDeAlocacao, x.FuncionarioId, x.RecursoId });
                    table.ForeignKey(
                        name: "FK_RecursoFuncionarios_Funcionarios_FuncionarioId",
                        column: x => x.FuncionarioId,
                        principalTable: "Funcionarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecursoFuncionarios_Recurso_RecursoId",
                        column: x => x.RecursoId,
                        principalTable: "Recurso",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sala",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Numero = table.Column<int>(type: "int", nullable: false),
                    Lugares = table.Column<int>(type: "int", nullable: false),
                    TemProjetor = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sala", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sala_Recurso_Id",
                        column: x => x.Id,
                        principalTable: "Recurso",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Funcionarios",
                columns: new[] { "Id", "Cargo", "DAdmissao", "Matricula", "Nome" },
                values: new object[,]
                {
                    { 1L, "Vendedor", new DateTime(2000, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 1234L, "João do pão" },
                    { 2L, "Vendedor", new DateTime(2000, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 1235L, "José da Manga" },
                    { 3L, "Vendedor", new DateTime(2000, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 1236L, "Maria Madalena" }
                });

            migrationBuilder.InsertData(
                table: "Recurso",
                column: "Id",
                values: new object[]
                {
                    1L,
                    2L,
                    3L
                });

            migrationBuilder.InsertData(
                table: "Laboratorio",
                columns: new[] { "Id", "Descricao", "Nome", "QComp" },
                values: new object[] { 2L, "Laboratório destinado ao aprendizado de CG", "Laboratório de computação gráfica", 30 });

            migrationBuilder.InsertData(
                table: "Notebooks",
                columns: new[] { "Id", "DAquisicao", "Descricao", "NroPatrimonio" },
                values: new object[] { 3L, new DateTime(2024, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "8 gb de ram, funciona, é da dell", 1002L });

            migrationBuilder.InsertData(
                table: "RecursoFuncionarios",
                columns: new[] { "DataDeAlocacao", "FuncionarioId", "RecursoId" },
                values: new object[] { new DateTime(2025, 8, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 1L, 2L });

            migrationBuilder.InsertData(
                table: "Sala",
                columns: new[] { "Id", "Lugares", "Numero", "TemProjetor" },
                values: new object[] { 1L, 30, 104, true });

            migrationBuilder.CreateIndex(
                name: "IX_RecursoFuncionarios_FuncionarioId",
                table: "RecursoFuncionarios",
                column: "FuncionarioId");

            migrationBuilder.CreateIndex(
                name: "IX_RecursoFuncionarios_RecursoId",
                table: "RecursoFuncionarios",
                column: "RecursoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Laboratorio");

            migrationBuilder.DropTable(
                name: "Notebooks");

            migrationBuilder.DropTable(
                name: "RecursoFuncionarios");

            migrationBuilder.DropTable(
                name: "Sala");

            migrationBuilder.DropTable(
                name: "Funcionarios");

            migrationBuilder.DropTable(
                name: "Recurso");
        }
    }
}
