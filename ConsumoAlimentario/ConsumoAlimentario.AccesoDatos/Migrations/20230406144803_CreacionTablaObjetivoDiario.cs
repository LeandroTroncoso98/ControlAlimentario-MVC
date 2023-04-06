using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConsumoAlimentario.AccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class CreacionTablaObjetivoDiario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ObjetivoDiario_Id",
                table: "Usuario",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ObjetivoDiario",
                columns: table => new
                {
                    ObjetivoDiario_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CaloriasObjetivo = table.Column<double>(type: "float", nullable: false),
                    CarbohidratosObjetivo = table.Column<double>(type: "float", nullable: false),
                    ProteinasObjetivo = table.Column<double>(type: "float", nullable: false),
                    GrasasObjetivo = table.Column<double>(type: "float", nullable: false),
                    SodioObjetivo = table.Column<double>(type: "float", nullable: false),
                    PotasioObjetivo = table.Column<double>(type: "float", nullable: false),
                    FibrasObjetivo = table.Column<double>(type: "float", nullable: false),
                    AzucarObjetivo = table.Column<double>(type: "float", nullable: false),
                    VitaminaAObjetivo = table.Column<double>(type: "float", nullable: false),
                    VitaminaCObjetivo = table.Column<double>(type: "float", nullable: false),
                    CalcioObjetivo = table.Column<double>(type: "float", nullable: false),
                    HierroObjetivo = table.Column<double>(type: "float", nullable: false),
                    Usuario_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ObjetivoDiario", x => x.ObjetivoDiario_Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_ObjetivoDiario_Id",
                table: "Usuario",
                column: "ObjetivoDiario_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_ObjetivoDiario_ObjetivoDiario_Id",
                table: "Usuario",
                column: "ObjetivoDiario_Id",
                principalTable: "ObjetivoDiario",
                principalColumn: "ObjetivoDiario_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_ObjetivoDiario_ObjetivoDiario_Id",
                table: "Usuario");

            migrationBuilder.DropTable(
                name: "ObjetivoDiario");

            migrationBuilder.DropIndex(
                name: "IX_Usuario_ObjetivoDiario_Id",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "ObjetivoDiario_Id",
                table: "Usuario");
        }
    }
}
