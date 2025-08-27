using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace src.Migrations
{
    /// <inheritdoc />
    public partial class AlocacaoDeRecursosV2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "NroPatrimonio",
                table: "Notebooks",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

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
                    table.PrimaryKey("PK_RecursoFuncionarios", x => x.DataDeAlocacao);
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
                name: "RecursoFuncionarios");

            migrationBuilder.DropColumn(
                name: "NroPatrimonio",
                table: "Notebooks");
        }
    }
}
