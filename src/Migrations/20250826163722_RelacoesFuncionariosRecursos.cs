using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace src.Migrations
{
    /// <inheritdoc />
    public partial class RelacoesFuncionariosRecursos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Laboratorios");

            migrationBuilder.DropTable(
                name: "Notebooks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Salas",
                table: "Salas");

            migrationBuilder.RenameTable(
                name: "Salas",
                newName: "Recurso");

            migrationBuilder.AlterColumn<bool>(
                name: "TemProjetor",
                table: "Recurso",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<int>(
                name: "Numero",
                table: "Recurso",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Lugares",
                table: "Recurso",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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
                name: "QComp",
                table: "Recurso",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Recurso",
                table: "Recurso",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "FuncionarioRecurso",
                columns: table => new
                {
                    FuncionariosId = table.Column<long>(type: "bigint", nullable: false),
                    RecursosAlocadosId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FuncionarioRecurso", x => new { x.FuncionariosId, x.RecursosAlocadosId });
                    table.ForeignKey(
                        name: "FK_FuncionarioRecurso_Funcionarios_FuncionariosId",
                        column: x => x.FuncionariosId,
                        principalTable: "Funcionarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FuncionarioRecurso_Recurso_RecursosAlocadosId",
                        column: x => x.RecursosAlocadosId,
                        principalTable: "Recurso",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FuncionarioRecurso_RecursosAlocadosId",
                table: "FuncionarioRecurso",
                column: "RecursosAlocadosId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FuncionarioRecurso");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Recurso",
                table: "Recurso");

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
                name: "Nome",
                table: "Recurso");

            migrationBuilder.DropColumn(
                name: "Notebook_Descricao",
                table: "Recurso");

            migrationBuilder.DropColumn(
                name: "QComp",
                table: "Recurso");

            migrationBuilder.RenameTable(
                name: "Recurso",
                newName: "Salas");

            migrationBuilder.AlterColumn<bool>(
                name: "TemProjetor",
                table: "Salas",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Numero",
                table: "Salas",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Lugares",
                table: "Salas",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Salas",
                table: "Salas",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Laboratorios",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QComp = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Laboratorios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Notebooks",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DAquisicao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notebooks", x => x.Id);
                });
        }
    }
}
