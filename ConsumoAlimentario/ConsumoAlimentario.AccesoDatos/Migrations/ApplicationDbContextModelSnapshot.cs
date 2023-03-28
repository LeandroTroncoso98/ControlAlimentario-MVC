﻿// <auto-generated />
using System;
using ConsumoAlimentario.AccesoDatos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ConsumoAlimentario.AccesoDatos.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ConsumoAlimentario.Models.Alimento", b =>
                {
                    b.Property<int>("Alimento_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Alimento_Id"));

                    b.Property<float>("Azucar")
                        .HasColumnType("real");

                    b.Property<float>("Calcio")
                        .HasColumnType("real");

                    b.Property<float>("Calorias")
                        .HasColumnType("real");

                    b.Property<float>("Cantidad")
                        .HasColumnType("real");

                    b.Property<float>("Carbohidratos")
                        .HasColumnType("real");

                    b.Property<float>("Fibra")
                        .HasColumnType("real");

                    b.Property<float>("GrasasTotales")
                        .HasColumnType("real");

                    b.Property<float>("Hierro")
                        .HasColumnType("real");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("nvarchar(70)");

                    b.Property<float>("Potasio")
                        .HasColumnType("real");

                    b.Property<float>("Proteina")
                        .HasColumnType("real");

                    b.Property<float>("Sodio")
                        .HasColumnType("real");

                    b.Property<float>("VitaminaA")
                        .HasColumnType("real");

                    b.Property<float>("VitaminaC")
                        .HasColumnType("real");

                    b.HasKey("Alimento_Id");

                    b.ToTable("Alimento");
                });

            modelBuilder.Entity("ConsumoAlimentario.Models.AlimentoCargado", b =>
                {
                    b.Property<int>("AlimentoCargado_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AlimentoCargado_Id"));

                    b.Property<int>("Alimento_Id")
                        .HasColumnType("int");

                    b.Property<float>("Azucar")
                        .HasColumnType("real");

                    b.Property<float>("Calcio")
                        .HasColumnType("real");

                    b.Property<float>("Calorias")
                        .HasColumnType("real");

                    b.Property<float>("Cantidad")
                        .HasColumnType("real");

                    b.Property<float>("Carbohidratos")
                        .HasColumnType("real");

                    b.Property<int>("ConsumoDiario_Id")
                        .HasColumnType("int");

                    b.Property<float>("Fibra")
                        .HasColumnType("real");

                    b.Property<float>("GrasasTotales")
                        .HasColumnType("real");

                    b.Property<float>("Hierro")
                        .HasColumnType("real");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Potasio")
                        .HasColumnType("real");

                    b.Property<float>("Proteina")
                        .HasColumnType("real");

                    b.Property<float>("Sodio")
                        .HasColumnType("real");

                    b.Property<float>("VitaminaA")
                        .HasColumnType("real");

                    b.Property<float>("VitaminaC")
                        .HasColumnType("real");

                    b.HasKey("AlimentoCargado_Id");

                    b.HasIndex("Alimento_Id");

                    b.HasIndex("ConsumoDiario_Id");

                    b.ToTable("AlimentoCargado");
                });

            modelBuilder.Entity("ConsumoAlimentario.Models.ConsumoDiario", b =>
                {
                    b.Property<int>("ConsumoDiario_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ConsumoDiario_Id"));

                    b.Property<float>("AzucarTotal")
                        .HasColumnType("real");

                    b.Property<float>("CalcioTotal")
                        .HasColumnType("real");

                    b.Property<float>("CaloriasTotales")
                        .HasColumnType("real");

                    b.Property<float>("CarbohidratosTotales")
                        .HasColumnType("real");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("Date");

                    b.Property<float>("FibrasTotales")
                        .HasColumnType("real");

                    b.Property<float>("GrasasTotales")
                        .HasColumnType("real");

                    b.Property<float>("HierroTotal")
                        .HasColumnType("real");

                    b.Property<float>("PotasioTotal")
                        .HasColumnType("real");

                    b.Property<float>("ProteinasTotales")
                        .HasColumnType("real");

                    b.Property<float>("SodioTotal")
                        .HasColumnType("real");

                    b.Property<float>("VitaminaATotal")
                        .HasColumnType("real");

                    b.Property<float>("VitaminaCTotal")
                        .HasColumnType("real");

                    b.HasKey("ConsumoDiario_Id");

                    b.ToTable("ConsumoDiario");
                });

            modelBuilder.Entity("ConsumoAlimentario.Models.AlimentoCargado", b =>
                {
                    b.HasOne("ConsumoAlimentario.Models.Alimento", "Alimento")
                        .WithMany("AlimentoCargado")
                        .HasForeignKey("Alimento_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ConsumoAlimentario.Models.ConsumoDiario", "ConsumoDiario")
                        .WithMany("ListaAlimentos")
                        .HasForeignKey("ConsumoDiario_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Alimento");

                    b.Navigation("ConsumoDiario");
                });

            modelBuilder.Entity("ConsumoAlimentario.Models.Alimento", b =>
                {
                    b.Navigation("AlimentoCargado");
                });

            modelBuilder.Entity("ConsumoAlimentario.Models.ConsumoDiario", b =>
                {
                    b.Navigation("ListaAlimentos");
                });
#pragma warning restore 612, 618
        }
    }
}
