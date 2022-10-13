using ApiColegio.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiColegio.Contexts
{
    public class ConexionSQLServer : DbContext
    {
        public ConexionSQLServer(DbContextOptions<ConexionSQLServer> options) : base(options)
        {

        }
        public DbSet<Estudiantes> Estudiantes { get; set; }
        // public DbSet<Cursos> Cursos { get; set; }
        public DbSet<Materias> Materias { get; set; }
        public DbSet<Profesores> Profesores { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /* modelBuilder.Entity<Cursos>(entity =>
             {
                 entity.HasKey(e => e.IdCurso);

                 entity.Property(e => e.IdCurso).HasColumnName("id_curso");

                 entity.Property(e => e.Nivel)
                     .HasMaxLength(10)
                     .HasColumnName("nivel")
                     .IsFixedLength();

                 entity.Property(e => e.Nombre)
                     .HasMaxLength(50)
                     .HasColumnName("nombre");

                 entity.Property(e => e.Seccion)
                     .HasMaxLength(10)
                     .HasColumnName("seccion")
                     .IsFixedLength();


                 entity.HasMany(d => d.Materias)
                      .WithMany(p => p.Cursos)
                      .UsingEntity<Dictionary<string, object>>(
                          "CursoMateria",
                          l => l.HasOne<Materias>().WithMany().HasForeignKey("IdMateria").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_Curso_Materias_Materias"),
                          r => r.HasOne<Cursos>().WithMany().HasForeignKey("IdCurso").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_Curso_Materias_Cursos"),
                          j =>
                          {
                              j.HasKey("IdCurso", "IdMateria");

                              j.ToTable("Curso_Materias");

                              j.IndexerProperty<int>("IdCurso").ValueGeneratedOnAdd().HasColumnName("id_curso");

                              j.IndexerProperty<int>("IdMateria").HasColumnName("id_materia");
                          }); 
             });*/

            modelBuilder.Entity<Estudiantes>(entity =>
            {
                entity.HasKey(e => e.IdEstudiante);

                entity.HasIndex(e => e.Telefono, "IX_Estudiantes")
                    .IsUnique();

                entity.Property(e => e.IdEstudiante).HasColumnName("id_estudiante");

                entity.Property(e => e.Apellido)
                    .HasMaxLength(50)
                    .HasColumnName("apellido");

                entity.Property(e => e.FechaNacimiento)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_nacimiento");

                // entity.Property(e => e.IdCurso).HasColumnName("id_curso");

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

                /* entity.HasOne(d => d.Curso)
                     .WithMany(p => p.Estudiantes)
                     .HasForeignKey(d => d.IdCurso)
                     .OnDelete(DeleteBehavior.ClientSetNull)
                     .HasConstraintName("FK_Estudiantes_Cursos"); */
            });


            modelBuilder.Entity<Materias>(entity =>
                {
                    entity.HasKey(e => e.IdMateria);

                    entity.Property(e => e.IdMateria).HasColumnName("id_materia");

                    entity.Property(e => e.Descripcion)
                        .HasMaxLength(255)
                        .HasColumnName("descripcion");

                    entity.Property(e => e.NombreCorto)
                        .HasMaxLength(15)
                        .HasColumnName("nombre_corto")
                        .IsFixedLength();

                    /*  entity.Property(e => e.IdCurso)
                      .HasColumnName("id_curso");

                      entity.HasOne(d=>d.Curso)
                      .WithMany(p=>p.Materias)
                      .OnDelete(DeleteBehavior.ClientSetNull)
                      .HasConstraintName("FK_Materias_Cursos"); */

                });

            modelBuilder.Entity<Materias>(entity =>
                        {

                            entity.HasMany(d => d.Estudiantes)
                      .WithMany(d => d.Materias)
                     .UsingEntity<Dictionary<string, object>>(
               "EstudianteMateria",
               l => l.HasOne<Estudiantes>().WithMany().HasForeignKey("IdEstudiante").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_Estudiante_Materia_Estudiantes"),
               r => r.HasOne<Materias>().WithMany().HasForeignKey("IdMateria").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_Estudiante_Materia_Materias"),
               j =>
               {
                   j.HasKey("IdEstudiante", "IdMateria");

                   j.ToTable("Estudiante_Materia");

                   j.IndexerProperty<int>("IdEstudiante").ValueGeneratedOnAdd().HasColumnName("id_Estudiante");

                   j.IndexerProperty<int>("IdMateria").HasColumnName("id_materia");

               });
            });
                modelBuilder.Entity<Profesores>(entity =>
                {
                    entity.HasKey(e => e.IdProfesor);

                    entity.HasIndex(e => e.IdMateria)
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

                    /* entity.HasOne(d => d.Materia)
                         .WithMany(p => p.Profesores)
                         .HasForeignKey(d => d.IdMateria)
                         .OnDelete(DeleteBehavior.ClientSetNull)
                         .HasConstraintName("FK_Profesores_Materias"); */
                });

            
        }
    }
}
