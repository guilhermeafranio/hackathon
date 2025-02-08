using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class AlterandoConsulta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Consulta_AspNetUsers_IdUsuario",
                table: "Consulta");

            migrationBuilder.DropIndex(
                name: "IX_Consulta_IdUsuario",
                table: "Consulta");

            migrationBuilder.DropColumn(
                name: "IdUsuario",
                table: "Consulta");

            migrationBuilder.CreateIndex(
                name: "IX_Consulta_IdPaciente",
                table: "Consulta",
                column: "IdPaciente");

            migrationBuilder.AddForeignKey(
                name: "FK_Consulta_AspNetUsers_IdPaciente",
                table: "Consulta",
                column: "IdPaciente",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Consulta_AspNetUsers_IdPaciente",
                table: "Consulta");

            migrationBuilder.DropIndex(
                name: "IX_Consulta_IdPaciente",
                table: "Consulta");

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
    }
}
