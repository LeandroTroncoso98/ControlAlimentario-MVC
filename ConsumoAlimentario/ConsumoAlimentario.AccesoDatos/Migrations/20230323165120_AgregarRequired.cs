using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConsumoAlimentario.AccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class AgregarRequired : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Alimento",
                columns: table => new
                {
                    Alimento_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    Calorias = table.Column<float>(type: "real", nullable: false),
                    Carbohidratos = table.Column<float>(type: "real", nullable: false),
                    Proteina = table.Column<float>(type: "real", nullable: false),
                    GrasasTotales = table.Column<float>(type: "real", nullable: false),
                    Sodio = table.Column<float>(type: "real", nullable: false),
                    Potasio = table.Column<float>(type: "real", nullable: false),
                    Fibra = table.Column<float>(type: "real", nullable: false),
                    Azucar = table.Column<float>(type: "real", nullable: false),
                    VitaminaA = table.Column<float>(type: "real", nullable: false),
                    VitaminaC = table.Column<float>(type: "real", nullable: false),
                    Calcio = table.Column<float>(type: "real", nullable: false),
                    Hierro = table.Column<float>(type: "real", nullable: false),
                    Cantidad = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alimento", x => x.Alimento_Id);
                });

            migrationBuilder.CreateTable(
                name: "ConsumoDiario",
                columns: table => new
                {
                    ConsumoDiario_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(type: "Date", nullable: false),
                    CaloriasTotales = table.Column<float>(type: "real", nullable: false),
                    CarbohidratosTotales = table.Column<float>(type: "real", nullable: false),
                    ProteinasTotales = table.Column<float>(type: "real", nullable: false),
                    GrasasTotales = table.Column<float>(type: "real", nullable: false),
                    SodioTotal = table.Column<float>(type: "real", nullable: false),
                    PotasioTotal = table.Column<float>(type: "real", nullable: false),
                    FibrasTotales = table.Column<float>(type: "real", nullable: false),
                    AzucarTotal = table.Column<float>(type: "real", nullable: false),
                    VitaminaATotal = table.Column<float>(type: "real", nullable: false),
                    VitaminaCTotal = table.Column<float>(type: "real", nullable: false),
                    CalcioTotal = table.Column<float>(type: "real", nullable: false),
                    HierroTotal = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsumoDiario", x => x.ConsumoDiario_Id);
                });

            migrationBuilder.CreateTable(
                name: "AlimentoCargado",
                columns: table => new
                {
                    AlimentoCargado_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Alimento_Id = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<float>(type: "real", nullable: false),
                    Calorias = table.Column<float>(type: "real", nullable: false),
                    Carbohidratos = table.Column<float>(type: "real", nullable: false),
                    Proteina = table.Column<float>(type: "real", nullable: false),
                    GrasasTotales = table.Column<float>(type: "real", nullable: false),
                    Sodio = table.Column<float>(type: "real", nullable: false),
                    Potasio = table.Column<float>(type: "real", nullable: false),
                    Fibra = table.Column<float>(type: "real", nullable: false),
                    Azucar = table.Column<float>(type: "real", nullable: false),
                    VitaminaA = table.Column<float>(type: "real", nullable: false),
                    VitaminaC = table.Column<float>(type: "real", nullable: false),
                    Calcio = table.Column<float>(type: "real", nullable: false),
                    Hierro = table.Column<float>(type: "real", nullable: false),
                    ConsumoDiario_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlimentoCargado", x => x.AlimentoCargado_Id);
                    table.ForeignKey(
                        name: "FK_AlimentoCargado_Alimento_Alimento_Id",
                        column: x => x.Alimento_Id,
                        principalTable: "Alimento",
                        principalColumn: "Alimento_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlimentoCargado_ConsumoDiario_ConsumoDiario_Id",
                        column: x => x.ConsumoDiario_Id,
                        principalTable: "ConsumoDiario",
                        principalColumn: "ConsumoDiario_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AlimentoCargado_Alimento_Id",
                table: "AlimentoCargado",
                column: "Alimento_Id");

            migrationBuilder.CreateIndex(
                name: "IX_AlimentoCargado_ConsumoDiario_Id",
                table: "AlimentoCargado",
                column: "ConsumoDiario_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlimentoCargado");

            migrationBuilder.DropTable(
                name: "Alimento");

            migrationBuilder.DropTable(
                name: "ConsumoDiario");
        }
    }
}
