using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace src.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "Notebooks",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Laboratorio",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "Laboratorio",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Funcionarios",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.InsertData(
                table: "Funcionarios",
                columns: new[] { "Id", "Cargo", "DAdmissao", "Matricula", "Nome" },
                values: new object[,]
                {
                    { 1L, "Vendedor", new DateTime(2025, 8, 28, 16, 44, 2, 942, DateTimeKind.Utc).AddTicks(729), 1234L, "João do pão" },
                    { 2L, "Vendedor", new DateTime(2025, 8, 28, 16, 44, 2, 942, DateTimeKind.Utc).AddTicks(1350), 1235L, "José da Manga" },
                    { 3L, "Vendedor", new DateTime(2025, 8, 28, 16, 44, 2, 942, DateTimeKind.Utc).AddTicks(1355), 1236L, "Maria Madalena" }
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
                values: new object[] { new DateTime(2025, 8, 28, 16, 44, 2, 944, DateTimeKind.Utc).AddTicks(8704), 1L, 2L });

            migrationBuilder.InsertData(
                table: "Sala",
                columns: new[] { "Id", "Lugares", "Numero", "TemProjetor" },
                values: new object[] { 1L, 30, 104, true });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Funcionarios",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Funcionarios",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Laboratorio",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Notebooks",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "RecursoFuncionarios",
                keyColumn: "DataDeAlocacao",
                keyValue: new DateTime(2025, 8, 28, 16, 44, 2, 944, DateTimeKind.Utc).AddTicks(8704));

            migrationBuilder.DeleteData(
                table: "Sala",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Funcionarios",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Recurso",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Recurso",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Recurso",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "Notebooks",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Laboratorio",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "Laboratorio",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Funcionarios",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);
        }
    }
}
