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

        public virtual DbSet<Course> Courses { get; set; } = null!;
        public virtual DbSet<Student> Students { get; set; } = null!;
        public virtual DbSet<Subject> Subjects { get; set; } = null!;
        public virtual DbSet<Teacher> Teachers { get; set; } = null!;
        public virtual DbSet<Grade> Grades { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>(entity =>
            {
                entity.HasKey(e => e.IdCourse);

                entity.Property(e => e.IdCourse).HasColumnName("id_curso");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("nombre");

                entity.Property(e => e.Section)
                    .HasMaxLength(10)
                    .HasColumnName("seccion")
                    .IsFixedLength();
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(e => e.IdStudent);

                entity.Property(e => e.IdStudent).HasColumnName("id_estudiante");

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .HasColumnName("apellido");

                entity.Property(e => e.Date)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_nacimiento");

                entity.Property(e => e.IdCourse).HasColumnName("id_curso");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .HasColumnName("nombre");

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(15)
                    .HasColumnName("telefono")
                    .IsFixedLength();

                entity.Property(e => e.Tutor)
                    .HasMaxLength(50)
                    .HasColumnName("tutor");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.IdCourse)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Estudiantes_Cursos");
            });

            modelBuilder.Entity<Subject>(entity =>
            {
                entity.HasKey(e => e.IdSubject);

                entity.Property(e => e.IdSubject).HasColumnName("id_materia");

                entity.Property(e => e.IdCourse).HasColumnName("id_curso");

              //  entity.Property(e => e.Level).HasMaxLength(255);

                entity.Property(e => e.Name)
                    .HasMaxLength(15)
                    .HasColumnName("nombre_corto")
                    .IsFixedLength();

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.Subjects)
                    .HasForeignKey(d => d.IdCourse)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Materias_Cursos");
            });

            modelBuilder.Entity<Teacher>(entity =>
            {
                entity.HasKey(e => e.IdTeacher);

                entity.HasIndex(e => e.IdSubject, "IX_Profesores")
                    .IsUnique();

                entity.Property(e => e.IdTeacher).HasColumnName("id_profesor");

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .HasColumnName("apellido");

                entity.Property(e => e.Date)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_nacimiento");

                entity.Property(e => e.IdSubject).HasColumnName("id_materia");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .HasColumnName("nombre");

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(15)
                    .HasColumnName("telefono")
                    .IsFixedLength();

                entity.HasOne(d => d.Subject)
                    .WithOne(p => p.Teacher)
                    .HasForeignKey<Teacher>(d => d.IdSubject)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Profesores_Materias");
            });
            modelBuilder.Entity<Grade>(entity =>
            {
              //  entity.Property(e => e.IdGrade).HasColumnName("id_nota");
                entity.Property(e => e.IdSubject).HasColumnName("id_materia");
                entity.Property(e => e.IdStudent).HasColumnName("id_estudiante");
                entity.Property(e => e.Qualification).HasColumnName("calificacion");

                entity.HasKey(e => new { e.IdStudent, e.IdSubject})
                    .HasName("PK_Grades");

                entity.HasOne(d => d.Student)
                .WithMany(p => p.Grades)
                .HasForeignKey(d => d.IdStudent)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Grades_Students");

                entity.HasOne(d => d.Subject)
                .WithMany(p => p.Grades)
                .HasForeignKey(d => d.IdSubject)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Grades_Subjects");
                
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
