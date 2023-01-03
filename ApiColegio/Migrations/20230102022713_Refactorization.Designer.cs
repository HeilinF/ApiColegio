﻿// <auto-generated />
using System;
using Domain.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ApiColegio.Migrations
{
    [DbContext(typeof(ConexionSQLServer))]
    [Migration("20230102022713_Refactorization")]
    partial class Refactorization
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Domain.Entities.Models.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Nombre");

                    b.Property<string>("Section")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)")
                        .HasColumnName("Seccion");

                    b.HasKey("Id");

                    b.ToTable("Curso");
                });

            modelBuilder.Entity("Domain.Entities.Models.Grade", b =>
                {
                    b.Property<int>("IdStudent")
                        .HasColumnType("int")
                        .HasColumnName("IdEstudiante");

                    b.Property<int>("IdSubject")
                        .HasColumnType("int")
                        .HasColumnName("IdMateria");

                    b.Property<int>("FirstPartial")
                        .HasColumnType("int")
                        .HasColumnName("PrimerParcial");

                    b.HasKey("IdStudent", "IdSubject");

                    b.HasIndex("IdSubject");

                    b.ToTable("Notas");
                });

            modelBuilder.Entity("Domain.Entities.Models.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2")
                        .HasColumnName("FechaDeNacimiento");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Nombre");

                    b.Property<int>("IdCourse")
                        .HasColumnType("int")
                        .HasColumnName("IdCurso");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Apellido");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)")
                        .HasColumnName("NumeroDeTelefono");

                    b.Property<string>("Tutor")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("TutorLegal");

                    b.HasKey("Id");

                    b.HasIndex("IdCourse");

                    b.ToTable("Estudiante");
                });

            modelBuilder.Entity("Domain.Entities.Models.Subject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("IdCourse")
                        .HasColumnType("int")
                        .HasColumnName("CursoId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)")
                        .HasColumnName("Nombre");

                    b.HasKey("Id");

                    b.HasIndex("IdCourse");

                    b.ToTable("Subjects");
                });

            modelBuilder.Entity("Domain.Entities.Models.Teacher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime?>("Date")
                        .HasColumnType("datetime2")
                        .HasColumnName("FechaDeNacimiento");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Nombre");

                    b.Property<int>("IdSubject")
                        .HasColumnType("int")
                        .HasColumnName("MateriaId");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Apellido");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)")
                        .HasColumnName("NumeroDeTelefono");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "IdSubject" }, "IX_Profesores")
                        .IsUnique();

                    b.ToTable("Teachers");
                });

            modelBuilder.Entity("Domain.Entities.Models.Grade", b =>
                {
                    b.HasOne("Domain.Entities.Models.Student", "Student")
                        .WithMany("Grades")
                        .HasForeignKey("IdStudent")
                        .IsRequired();

                    b.HasOne("Domain.Entities.Models.Subject", "Subject")
                        .WithMany("Grades")
                        .HasForeignKey("IdSubject")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.Navigation("Student");

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("Domain.Entities.Models.Student", b =>
                {
                    b.HasOne("Domain.Entities.Models.Course", "Course")
                        .WithMany("Students")
                        .HasForeignKey("IdCourse")
                        .IsRequired();

                    b.Navigation("Course");
                });

            modelBuilder.Entity("Domain.Entities.Models.Subject", b =>
                {
                    b.HasOne("Domain.Entities.Models.Course", "Course")
                        .WithMany("Subjects")
                        .HasForeignKey("IdCourse")
                        .IsRequired();

                    b.Navigation("Course");
                });

            modelBuilder.Entity("Domain.Entities.Models.Teacher", b =>
                {
                    b.HasOne("Domain.Entities.Models.Subject", "Subject")
                        .WithOne("Teacher")
                        .HasForeignKey("Domain.Entities.Models.Teacher", "IdSubject")
                        .IsRequired();

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("Domain.Entities.Models.Course", b =>
                {
                    b.Navigation("Students");

                    b.Navigation("Subjects");
                });

            modelBuilder.Entity("Domain.Entities.Models.Student", b =>
                {
                    b.Navigation("Grades");
                });

            modelBuilder.Entity("Domain.Entities.Models.Subject", b =>
                {
                    b.Navigation("Grades");

                    b.Navigation("Teacher");
                });
#pragma warning restore 612, 618
        }
    }
}