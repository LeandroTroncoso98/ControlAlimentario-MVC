using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConsumoAlimentario.AccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class CreacionTablasUsuarioClienteCorreccion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PassWord",
                table: "Usuario",
                newName: "Password");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Usuario",
                newName: "PassWord");
        }
    }
}
