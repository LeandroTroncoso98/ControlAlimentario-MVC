using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConsumoAlimentario.AccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class CreacionTablasUsuarioCliente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Cliente_Id",
                table: "ConsumoDiario",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    Cliente_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Peso = table.Column<double>(type: "float", nullable: false),
                    Altura = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.Cliente_Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Usuario_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PassWord = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cliente_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Usuario_Id);
                    table.ForeignKey(
                        name: "FK_Usuario_Cliente_Cliente_id",
                        column: x => x.Cliente_id,
                        principalTable: "Cliente",
                        principalColumn: "Cliente_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ConsumoDiario_Cliente_Id",
                table: "ConsumoDiario",
                column: "Cliente_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_Cliente_id",
                table: "Usuario",
                column: "Cliente_id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ConsumoDiario_Cliente_Cliente_Id",
                table: "ConsumoDiario",
                column: "Cliente_Id",
                principalTable: "Cliente",
                principalColumn: "Cliente_Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConsumoDiario_Cliente_Cliente_Id",
                table: "ConsumoDiario");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropIndex(
                name: "IX_ConsumoDiario_Cliente_Id",
                table: "ConsumoDiario");

            migrationBuilder.DropColumn(
                name: "Cliente_Id",
                table: "ConsumoDiario");
        }
    }
}
