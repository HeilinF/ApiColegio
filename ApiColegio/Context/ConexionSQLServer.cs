using System;
using System.Collections.Generic;
using ApiColegio.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ApiColegio.Context
{
    public partial class ConexionSQLServer : DbContext
    {
        public ConexionSQLServer()
        {
        }

        public ConexionSQLServer(DbContextOptions<ConexionSQLServer> options)
            : base(options)
        {
        }

        public virtual DbSet<Curso> Cursos { get; set; } = null!;
        public virtual DbSet<Estudiante> Estudiantes { get; set; } = null!;
        public virtual DbSet<Materia> Materias { get; set; } = null!;
        public virtual DbSet<Profesor> Profesores { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
               optionsBuilder.UseSqlServer("Server=LAPTOP-O2E6A0VL; Database=Colegio; Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Curso>(entity =>
            {
                entity.HasKey(e => e.IdCurso);

                entity.Property(e => e.IdCurso).HasColumnName("id_curso");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .HasColumnName("nombre");

                entity.Property(e => e.Seccion)
                    .HasMaxLength(10)
                    .HasColumnName("seccion")
                    .IsFixedLength();
            });

            modelBuilder.Entity<Estudiante>(entity =>
            {
                entity.HasKey(e => e.IdEstudiante);

                entity.Property(e => e.IdEstudiante).HasColumnName("id_estudiante");

                entity.Property(e => e.Apellido)
                    .HasMaxLength(50)
                    .HasColumnName("apellido");

                entity.Property(e => e.FechaNacimiento)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_nacimiento");

                entity.Property(e => e.IdCurso).HasColumnName("id_curso");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .HasColumnName("nombre");

                entity.Property(e => e.Telefono)
                    .HasMaxLength(15)
                    .HasColumnName("telefono")
                    .IsFixedLength();

                entity.Property(e => e.Tutor)
                    .HasMaxLength(50)
                    .HasColumnName("tutor");

                entity.HasOne(d => d.Curso)
                    .WithMany(p => p.Estudiantes)
                    .HasForeignKey(d => d.IdCurso)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Estudiantes_Cursos");
            });

            modelBuilder.Entity<Materia>(entity =>
            {
                entity.HasKey(e => e.IdMateria);

                entity.Property(e => e.IdMateria).HasColumnName("id_materia");

                entity.Property(e => e.IdCurso).HasColumnName("id_curso");

                entity.Property(e => e.Nivel).HasMaxLength(255);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(15)
                    .HasColumnName("nombre_corto")
                    .IsFixedLength();

                entity.HasOne(d => d.Curso)
                    .WithMany(p => p.Materias)
                    .HasForeignKey(d => d.IdCurso)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Materias_Cursos");
            });

            modelBuilder.Entity<Profesor>(entity =>
            {
                entity.HasKey(e => e.IdProfesor);

                entity.HasIndex(e => e.IdMateria, "IX_Profesores")
                    .IsUnique();

                entity.Property(e => e.IdProfesor).HasColumnName("id_profesor");

                entity.Property(e => e.Apellido)
                    .HasMaxLength(50)
                    .HasColumnName("apellido");

                entity.Property(e => e.FechaNacimiento)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_nacimiento");

                entity.Property(e => e.IdMateria).HasColumnName("id_materia");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .HasColumnName("nombre");

                entity.Property(e => e.Telefono)
                    .HasMaxLength(15)
                    .HasColumnName("telefono")
                    .IsFixedLength();

                entity.HasOne(d => d.Materia)
                    .WithOne(p => p.Profesor)
                    .HasForeignKey<Profesor>(d => d.IdMateria)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Profesores_Materias");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
