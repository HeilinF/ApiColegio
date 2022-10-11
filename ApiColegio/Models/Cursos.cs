using System.ComponentModel.DataAnnotations;

namespace ApiColegio.Models
{
    public class Cursos
    {
      /*  public Cursos()
        {
            Estudiantes = new HashSet<Estudiantes>();
        }
      */
       [Key] public int id_curso { get; set; }

        [Required] public string nombre { get; set; }
        public string nivel { get; set;}
        public char seccion { get; set;}

        //public virtual ICollection<Estudiantes>? Estudiantes { get; set; }
    }
}
