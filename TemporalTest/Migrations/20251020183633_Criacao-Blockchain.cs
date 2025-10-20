using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TemporalTest.Migrations
{
    /// <inheritdoc />
    public partial class CriacaoBlockchain : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DataCadastro",
                table: "Usuario",
                newName: "DataInsercao");

            migrationBuilder.AddColumn<string>(
                name: "Dados",
                table: "Usuario",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Hash",
                table: "Usuario",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "IP",
                table: "Usuario",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Localizacao",
                table: "Usuario",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "OldHash",
                table: "Usuario",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PerfilAcessoInsercao",
                table: "Usuario",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Dados",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "Hash",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "IP",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "Localizacao",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "OldHash",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "PerfilAcessoInsercao",
                table: "Usuario");

            migrationBuilder.RenameColumn(
                name: "DataInsercao",
                table: "Usuario",
                newName: "DataCadastro");
        }
    }
}
