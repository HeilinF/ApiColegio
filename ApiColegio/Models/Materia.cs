using System.ComponentModel.DataAnnotations;

namespace ApiColegio.Models
{
    public class Materia
    {
       // public Materia()
       // {
          //  Estudiantes= new HashSet<Student>();
       //     Profesores = new HashSet<Profesor>();
       // }

        public int IdMateria { get; set; }
        public string Nombre { get; set; } = null!;
        public string Nivel { get; set; }=null!;
        public int IdCurso { get; set; }
        public virtual Curso Curso { get; set; }= null!;

        public virtual Profesor? Profesor { get; set; }
       // public virtual ICollection<Student> Estudiantes { get;}


    }
}
