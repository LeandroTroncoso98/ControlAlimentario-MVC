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

                    b.Property<double>("Azucar")
                        .HasColumnType("float");

                    b.Property<double>("Calcio")
                        .HasColumnType("float");

                    b.Property<double>("Calorias")
                        .HasColumnType("float");

                    b.Property<double>("Cantidad")
                        .HasColumnType("float");

                    b.Property<double>("Carbohidratos")
                        .HasColumnType("float");

                    b.Property<double>("Fibra")
                        .HasColumnType("float");

                    b.Property<double>("GrasasTotales")
                        .HasColumnType("float");

                    b.Property<double>("Hierro")
                        .HasColumnType("float");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("nvarchar(70)");

                    b.Property<double>("Potasio")
                        .HasColumnType("float");

                    b.Property<double>("Proteina")
                        .HasColumnType("float");

                    b.Property<double>("Sodio")
                        .HasColumnType("float");

                    b.Property<double>("VitaminaA")
                        .HasColumnType("float");

                    b.Property<double>("VitaminaC")
                        .HasColumnType("float");

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

                    b.Property<double>("Azucar")
                        .HasColumnType("float");

                    b.Property<double>("Calcio")
                        .HasColumnType("float");

                    b.Property<double>("Calorias")
                        .HasColumnType("float");

                    b.Property<double>("Cantidad")
                        .HasColumnType("float");

                    b.Property<double>("Carbohidratos")
                        .HasColumnType("float");

                    b.Property<int>("ConsumoDiario_Id")
                        .HasColumnType("int");

                    b.Property<double>("Fibra")
                        .HasColumnType("float");

                    b.Property<double>("GrasasTotales")
                        .HasColumnType("float");

                    b.Property<double>("Hierro")
                        .HasColumnType("float");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Potasio")
                        .HasColumnType("float");

                    b.Property<double>("Proteina")
                        .HasColumnType("float");

                    b.Property<double>("Sodio")
                        .HasColumnType("float");

                    b.Property<double>("VitaminaA")
                        .HasColumnType("float");

                    b.Property<double>("VitaminaC")
                        .HasColumnType("float");

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

                    b.Property<double>("AzucarTotal")
                        .HasColumnType("float");

                    b.Property<double>("CalcioTotal")
                        .HasColumnType("float");

                    b.Property<double>("CaloriasTotales")
                        .HasColumnType("float");

                    b.Property<double>("CarbohidratosTotales")
                        .HasColumnType("float");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("Date");

                    b.Property<double>("FibrasTotales")
                        .HasColumnType("float");

                    b.Property<double>("GrasasTotales")
                        .HasColumnType("float");

                    b.Property<double>("HierroTotal")
                        .HasColumnType("float");

                    b.Property<double>("PotasioTotal")
                        .HasColumnType("float");

                    b.Property<double>("ProteinasTotales")
                        .HasColumnType("float");

                    b.Property<double>("SodioTotal")
                        .HasColumnType("float");

                    b.Property<int>("Usuario_Id")
                        .HasColumnType("int");

                    b.Property<double>("VitaminaATotal")
                        .HasColumnType("float");

                    b.Property<double>("VitaminaCTotal")
                        .HasColumnType("float");

                    b.HasKey("ConsumoDiario_Id");

                    b.HasIndex("Usuario_Id");

                    b.ToTable("ConsumoDiario");
                });

            modelBuilder.Entity("ConsumoAlimentario.Models.Usuario", b =>
                {
                    b.Property<int>("Usuario_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Usuario_Id"));

                    b.Property<double>("Altura")
                        .HasColumnType("float");

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Peso")
                        .HasColumnType("float");

                    b.HasKey("Usuario_Id");

                    b.ToTable("Usuario");
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

            modelBuilder.Entity("ConsumoAlimentario.Models.ConsumoDiario", b =>
                {
                    b.HasOne("ConsumoAlimentario.Models.Usuario", "Usuario")
                        .WithMany("ListaConsumoDiario")
                        .HasForeignKey("Usuario_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("ConsumoAlimentario.Models.Alimento", b =>
                {
                    b.Navigation("AlimentoCargado");
                });

            modelBuilder.Entity("ConsumoAlimentario.Models.ConsumoDiario", b =>
                {
                    b.Navigation("ListaAlimentos");
                });

            modelBuilder.Entity("ConsumoAlimentario.Models.Usuario", b =>
                {
                    b.Navigation("ListaConsumoDiario");
                });
#pragma warning restore 612, 618
        }
    }
}
