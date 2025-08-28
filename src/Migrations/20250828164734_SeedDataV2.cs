using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace src.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataV2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RecursoFuncionarios",
                keyColumn: "DataDeAlocacao",
                keyValue: new DateTime(2025, 8, 28, 16, 44, 2, 944, DateTimeKind.Utc).AddTicks(8704));

            migrationBuilder.UpdateData(
                table: "Funcionarios",
                keyColumn: "Id",
                keyValue: 1L,
                column: "DAdmissao",
                value: new DateTime(2000, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Funcionarios",
                keyColumn: "Id",
                keyValue: 2L,
                column: "DAdmissao",
                value: new DateTime(2000, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Funcionarios",
                keyColumn: "Id",
                keyValue: 3L,
                column: "DAdmissao",
                value: new DateTime(2000, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "RecursoFuncionarios",
                columns: new[] { "DataDeAlocacao", "FuncionarioId", "RecursoId" },
                values: new object[] { new DateTime(2025, 8, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 1L, 2L });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RecursoFuncionarios",
                keyColumn: "DataDeAlocacao",
                keyValue: new DateTime(2025, 8, 30, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Funcionarios",
                keyColumn: "Id",
                keyValue: 1L,
                column: "DAdmissao",
                value: new DateTime(2025, 8, 28, 16, 44, 2, 942, DateTimeKind.Utc).AddTicks(729));

            migrationBuilder.UpdateData(
                table: "Funcionarios",
                keyColumn: "Id",
                keyValue: 2L,
                column: "DAdmissao",
                value: new DateTime(2025, 8, 28, 16, 44, 2, 942, DateTimeKind.Utc).AddTicks(1350));

            migrationBuilder.UpdateData(
                table: "Funcionarios",
                keyColumn: "Id",
                keyValue: 3L,
                column: "DAdmissao",
                value: new DateTime(2025, 8, 28, 16, 44, 2, 942, DateTimeKind.Utc).AddTicks(1355));

            migrationBuilder.InsertData(
                table: "RecursoFuncionarios",
                columns: new[] { "DataDeAlocacao", "FuncionarioId", "RecursoId" },
                values: new object[] { new DateTime(2025, 8, 28, 16, 44, 2, 944, DateTimeKind.Utc).AddTicks(8704), 1L, 2L });
        }
    }
}
