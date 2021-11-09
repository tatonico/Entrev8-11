﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using entrevista.Models;

namespace entrevista.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20211109033603_s3")]
    partial class s3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("entrevista.Models.Certificacion", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("certificacion")
                        .HasColumnType("int");

                    b.Property<string>("descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("emision")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("vencimiento")
                        .HasColumnType("datetime2");

                    b.HasKey("id");

                    b.ToTable("Certificacion");
                });

            modelBuilder.Entity("entrevista.Models.Curso", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("contactoId")
                        .HasColumnType("int");

                    b.Property<string>("descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("empresaId")
                        .HasColumnType("int");

                    b.Property<int>("modalidad")
                        .HasColumnType("int");

                    b.Property<string>("titulo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("contactoId");

                    b.HasIndex("empresaId");

                    b.ToTable("Curso");
                });

            modelBuilder.Entity("entrevista.Models.Empresa", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("direccion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("razonSocial")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("telefono")
                        .HasColumnType("int");

                    b.Property<string>("web")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Empresa");
                });

            modelBuilder.Entity("entrevista.Models.Fecha", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("Cursoid")
                        .HasColumnType("int");

                    b.Property<DateTime>("Value")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("Cursoid");

                    b.ToTable("Fecha");
                });

            modelBuilder.Entity("entrevista.Models.Persona", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("Empresaid")
                        .HasColumnType("int");

                    b.Property<string>("mail")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("Empresaid");

                    b.ToTable("Persona");
                });

            modelBuilder.Entity("entrevista.Models.Curso", b =>
                {
                    b.HasOne("entrevista.Models.Persona", "contacto")
                        .WithMany("cursos")
                        .HasForeignKey("contactoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("entrevista.Models.Empresa", "empresa")
                        .WithMany()
                        .HasForeignKey("empresaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("entrevista.Models.Fecha", b =>
                {
                    b.HasOne("entrevista.Models.Curso", null)
                        .WithMany("fechas")
                        .HasForeignKey("Cursoid");
                });

            modelBuilder.Entity("entrevista.Models.Persona", b =>
                {
                    b.HasOne("entrevista.Models.Empresa", null)
                        .WithMany("contactos")
                        .HasForeignKey("Empresaid");
                });
#pragma warning restore 612, 618
        }
    }
}
