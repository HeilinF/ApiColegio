using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.Models
{
    public class Subject: EntityBase
    {
        //public Subject()
        //{
        //    //  Estudiantes = new HashSet<Student>();
        //    // Profesores = new HashSet<Profesor>();
        //    Grades = new HashSet<Grade>();
        //}

        [Column("Nombre")]
        public string Name { get; set; } = null!;
        //public string Level { get; set; }=null!;
        [Column("CursoId"), ForeignKey("FK_Materias_Cursos")]
        public int IdCourse { get; set; }
        public virtual Course Course { get; set; } = null!;

        public virtual Teacher? Teacher { get; set; }

        public virtual ICollection<Grade> Grades { get; set; }
        // public virtual ICollection<Student> Estudiantes { get;}


    }
}
