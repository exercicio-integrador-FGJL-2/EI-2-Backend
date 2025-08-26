using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace src.Migrations
{
    /// <inheritdoc />
    public partial class RelacoesTabelasDiferentes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DAquisicao",
                table: "Recurso");

            migrationBuilder.DropColumn(
                name: "Descricao",
                table: "Recurso");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Recurso");

            migrationBuilder.DropColumn(
                name: "Lugares",
                table: "Recurso");

            migrationBuilder.DropColumn(
                name: "Nome",
                table: "Recurso");

            migrationBuilder.DropColumn(
                name: "Notebook_Descricao",
                table: "Recurso");

            migrationBuilder.DropColumn(
                name: "Numero",
                table: "Recurso");

            migrationBuilder.DropColumn(
                name: "QComp",
                table: "Recurso");

            migrationBuilder.DropColumn(
                name: "TemProjetor",
                table: "Recurso");

            migrationBuilder.CreateTable(
                name: "Laboratorio",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QComp = table.Column<int>(type: "int", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                    DAquisicao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Laboratorio");

            migrationBuilder.DropTable(
                name: "Notebooks");

            migrationBuilder.DropTable(
                name: "Sala");

            migrationBuilder.AddColumn<DateTime>(
                name: "DAquisicao",
                table: "Recurso",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Descricao",
                table: "Recurso",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Recurso",
                type: "nvarchar(13)",
                maxLength: 13,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Lugares",
                table: "Recurso",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "Recurso",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Notebook_Descricao",
                table: "Recurso",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Numero",
                table: "Recurso",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "QComp",
                table: "Recurso",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "TemProjetor",
                table: "Recurso",
                type: "bit",
                nullable: true);
        }
    }
}
