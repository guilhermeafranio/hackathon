using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class PacienteConsulta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IdPaciente",
                table: "Consulta",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "IdUsuario",
                table: "Consulta",
                type: "text",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Consulta_IdUsuario",
                table: "Consulta",
                column: "IdUsuario");

            migrationBuilder.AddForeignKey(
                name: "FK_Consulta_AspNetUsers_IdUsuario",
                table: "Consulta",
                column: "IdUsuario",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Consulta_AspNetUsers_IdUsuario",
                table: "Consulta");

            migrationBuilder.DropIndex(
                name: "IX_Consulta_IdUsuario",
                table: "Consulta");

            migrationBuilder.DropColumn(
                name: "IdPaciente",
                table: "Consulta");

            migrationBuilder.DropColumn(
                name: "IdUsuario",
                table: "Consulta");
        }
    }
}
