using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConsumoAlimentario.AccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class UnificacionClienteUsuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConsumoDiario_Cliente_Cliente_Id",
                table: "ConsumoDiario");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.RenameColumn(
                name: "Cliente_Id",
                table: "ConsumoDiario",
                newName: "Usuario_Id");

            migrationBuilder.RenameIndex(
                name: "IX_ConsumoDiario_Cliente_Id",
                table: "ConsumoDiario",
                newName: "IX_ConsumoDiario_Usuario_Id");

            migrationBuilder.AddColumn<double>(
                name: "Altura",
                table: "Usuario",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "Apellido",
                table: "Usuario",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Nombre",
                table: "Usuario",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "Peso",
                table: "Usuario",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddForeignKey(
                name: "FK_ConsumoDiario_Usuario_Usuario_Id",
                table: "ConsumoDiario",
                column: "Usuario_Id",
                principalTable: "Usuario",
                principalColumn: "Usuario_Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConsumoDiario_Usuario_Usuario_Id",
                table: "ConsumoDiario");

            migrationBuilder.DropColumn(
                name: "Altura",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "Apellido",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "Nombre",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "Peso",
                table: "Usuario");

            migrationBuilder.RenameColumn(
                name: "Usuario_Id",
                table: "ConsumoDiario",
                newName: "Cliente_Id");

            migrationBuilder.RenameIndex(
                name: "IX_ConsumoDiario_Usuario_Id",
                table: "ConsumoDiario",
                newName: "IX_ConsumoDiario_Cliente_Id");

            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    Cliente_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Usuario_Id = table.Column<int>(type: "int", nullable: false),
                    Altura = table.Column<double>(type: "float", nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Peso = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.Cliente_Id);
                    table.ForeignKey(
                        name: "FK_Cliente_Usuario_Usuario_Id",
                        column: x => x.Usuario_Id,
                        principalTable: "Usuario",
                        principalColumn: "Usuario_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_Usuario_Id",
                table: "Cliente",
                column: "Usuario_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ConsumoDiario_Cliente_Cliente_Id",
                table: "ConsumoDiario",
                column: "Cliente_Id",
                principalTable: "Cliente",
                principalColumn: "Cliente_Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
