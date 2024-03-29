﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Tools.Loan.DataAcces;

namespace Tools.Loan.DataAcces.Migrations
{
    [DbContext(typeof(AppContext))]
    [Migration("20201107213130_nuevocmbio")]
    partial class nuevocmbio
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.0-rtm-30799")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Tools.Loan.Domain.Categoria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nombre");

                    b.HasKey("Id");

                    b.HasIndex("Nombre")
                        .IsUnique()
                        .HasFilter("[Nombre] IS NOT NULL");

                    b.ToTable("Categoria");
                });

            modelBuilder.Entity("Tools.Loan.Domain.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Apellido");

                    b.Property<string>("Cargo");

                    b.Property<string>("Identificacion")
                        .IsRequired();

                    b.Property<string>("Nombre");

                    b.HasKey("Id");

                    b.HasIndex("Identificacion")
                        .IsUnique();

                    b.ToTable("Cliente");

                    b.HasData(
                        new { Id = 1, Apellido = "wilimardo", Cargo = "Solgat", Identificacion = "154151545454", Nombre = "Wili" }
                    );
                });

            modelBuilder.Entity("Tools.Loan.Domain.Herramienta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descripción");

                    b.Property<int>("HerramientaMetaDataID");

                    b.Property<string>("Puesto");

                    b.Property<DateTime?>("Rentada");

                    b.HasKey("Id");

                    b.HasIndex("HerramientaMetaDataID");

                    b.ToTable("Herramienta");

                    b.HasData(
                        new { Id = 1, Descripción = "N/A", HerramientaMetaDataID = 1 },
                        new { Id = 2, Descripción = "N/A", HerramientaMetaDataID = 1 },
                        new { Id = 3, Descripción = "N/A", HerramientaMetaDataID = 1 },
                        new { Id = 4, Descripción = "N/A", HerramientaMetaDataID = 1 }
                    );
                });

            modelBuilder.Entity("Tools.Loan.Domain.HerramientaMetaData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CategoriaId");

                    b.Property<string>("Marca");

                    b.Property<string>("Nombre");

                    b.Property<string>("Serial");

                    b.HasKey("Id");

                    b.HasIndex("CategoriaId");

                    b.ToTable("HerramientaMetaData");

                    b.HasData(
                        new { Id = 1, Marca = "Cat", Nombre = "Martillo", Serial = "AFFFD234" }
                    );
                });

            modelBuilder.Entity("Tools.Loan.Domain.Prestamo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClienteId");

                    b.Property<string>("Descripción");

                    b.Property<DateTime>("FechaEntrada");

                    b.Property<DateTime>("FechaSalida");

                    b.Property<DateTime?>("HerramientaDevultaFecha");

                    b.Property<int>("HerramientaId");

                    b.Property<int>("UsuarioId");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.HasIndex("HerramientaId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Prestamo");

                    b.HasData(
                        new { Id = 1, ClienteId = 1, Descripción = "Presto un martillo ", FechaEntrada = new DateTime(2020, 11, 7, 21, 31, 28, 490, DateTimeKind.Utc), FechaSalida = new DateTime(2020, 11, 10, 21, 31, 28, 490, DateTimeKind.Utc), HerramientaId = 1, UsuarioId = 1 }
                    );
                });

            modelBuilder.Entity("Tools.Loan.Domain.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasMaxLength(22);

                    b.HasKey("Id");

                    b.HasIndex("RoleName")
                        .IsUnique();

                    b.ToTable("Role");

                    b.HasData(
                        new { Id = 1, RoleName = "Admin" },
                        new { Id = 2, RoleName = "Encargado" }
                    );
                });

            modelBuilder.Entity("Tools.Loan.Domain.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nombre");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(22);

                    b.Property<int>("RoleId");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(22);

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserName")
                        .IsUnique();

                    b.ToTable("Usuario");

                    b.HasData(
                        new { Id = 1, Nombre = "Admin", Password = "123", RoleId = 1, UserName = "Admin" }
                    );
                });

            modelBuilder.Entity("Tools.Loan.Domain.Herramienta", b =>
                {
                    b.HasOne("Tools.Loan.Domain.HerramientaMetaData", "HerramientaMetaData")
                        .WithMany("Herramientas")
                        .HasForeignKey("HerramientaMetaDataID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Tools.Loan.Domain.HerramientaMetaData", b =>
                {
                    b.HasOne("Tools.Loan.Domain.Categoria", "Categoria")
                        .WithMany("HerramientaMetaDatas")
                        .HasForeignKey("CategoriaId");
                });

            modelBuilder.Entity("Tools.Loan.Domain.Prestamo", b =>
                {
                    b.HasOne("Tools.Loan.Domain.Cliente", "Cliente")
                        .WithMany("Prestamos")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Tools.Loan.Domain.Herramienta", "Herramienta")
                        .WithMany("Prestamos")
                        .HasForeignKey("HerramientaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Tools.Loan.Domain.Usuario", "Usuario")
                        .WithMany("Prestamos")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Tools.Loan.Domain.Usuario", b =>
                {
                    b.HasOne("Tools.Loan.Domain.Role", "Role")
                        .WithMany("Usuarios")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
