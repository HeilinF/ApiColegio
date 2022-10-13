using System.ComponentModel.DataAnnotations;

namespace ApiColegio.Models
{
    public class Materias
    {
      /*  public Materias()
        {
            Estudiantes= new HashSet<Estudiantes>();
        //    Profesores = new HashSet<Profesores>();
        }*/

        public int IdMateria { get; set; }
        public string NombreCorto { get; set; }
        public string Descripcion { get; set; }



        // public int IdCurso { get; set; }
        //  public virtual ICollection<Profesores> Profesores { get; set; }

        //  public virtual Cursos Curso { get; set; }

        public virtual ICollection<Estudiantes> Estudiantes { get; set; }


    }
}
