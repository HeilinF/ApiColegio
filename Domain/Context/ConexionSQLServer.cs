using System;
using System.Collections.Generic;
using Domain.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Domain.Context
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
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id);

                entity.Property(e => e.Name)
                    .HasMaxLength(50) ;

                entity.Property(e => e.Section)
                    .HasMaxLength(10);
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id);

                entity.Property(e => e.LastName)
                    .HasMaxLength(50);

                entity.Property(e => e.Date); ;

                entity.Property(e => e.IdCourse);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50);

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(15);

                entity.Property(e => e.Tutor)
                    .HasMaxLength(50);

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.IdCourse)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Subject>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id);

                entity.Property(e => e.IdCourse);

                //  entity.Property(e => e.Level).HasMaxLength(255);

                entity.Property(e => e.Name)
                    .HasMaxLength(15);

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.Subjects)
                    .HasForeignKey(d => d.IdCourse)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Teacher>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.HasIndex(e => e.IdSubject, "IX_Profesores")
                    .IsUnique();

                entity.Property(e => e.Id);

                entity.Property(e => e.LastName)
                    .HasMaxLength(50);

                entity.Property(e => e.Date);

                entity.Property(e => e.IdSubject);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50);

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(15);

                entity.HasOne(d => d.Subject)
                    .WithOne(p => p.Teacher)
                    .HasForeignKey<Teacher>(d => d.IdSubject)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });
            modelBuilder.Entity<Grade>(entity =>
            {
                //  entity.Property(e => e.IdGrade).HasColumnName("id_nota");
                entity.Property(e => e.IdSubject);
                entity.Property(e => e.IdStudent);
                entity.Property(e => e.FirstPartial);
                //entity.Property(e => e.SecondPartial).HasColumnName("segundo_parcial");
                //entity.Property(e => e.ThirdPartial).HasColumnName("tercer_parcial");

                entity.HasKey(e => new { e.IdStudent, e.IdSubject });

                entity.HasOne(d => d.Student)
                .WithMany(p => p.Grades)
                .HasForeignKey(d => d.IdStudent)
                .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Subject)
                .WithMany(p => p.Grades)
                .HasForeignKey(d => d.IdSubject)
                .OnDelete(DeleteBehavior.ClientCascade);

            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
