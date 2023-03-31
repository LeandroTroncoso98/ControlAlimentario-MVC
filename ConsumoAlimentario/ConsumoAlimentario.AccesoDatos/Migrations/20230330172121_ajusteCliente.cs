using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConsumoAlimentario.AccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class ajusteCliente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_Cliente_Cliente_id",
                table: "Usuario");

            migrationBuilder.DropIndex(
                name: "IX_Usuario_Cliente_id",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "Cliente_id",
                table: "Usuario");

            migrationBuilder.AddColumn<int>(
                name: "Usuario_Id",
                table: "Cliente",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_Usuario_Id",
                table: "Cliente",
                column: "Usuario_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cliente_Usuario_Usuario_Id",
                table: "Cliente",
                column: "Usuario_Id",
                principalTable: "Usuario",
                principalColumn: "Usuario_Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cliente_Usuario_Usuario_Id",
                table: "Cliente");

            migrationBuilder.DropIndex(
                name: "IX_Cliente_Usuario_Id",
                table: "Cliente");

            migrationBuilder.DropColumn(
                name: "Usuario_Id",
                table: "Cliente");

            migrationBuilder.AddColumn<int>(
                name: "Cliente_id",
                table: "Usuario",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_Cliente_id",
                table: "Usuario",
                column: "Cliente_id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_Cliente_Cliente_id",
                table: "Usuario",
                column: "Cliente_id",
                principalTable: "Cliente",
                principalColumn: "Cliente_Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
