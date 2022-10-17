using System.ComponentModel.DataAnnotations;

namespace ApiColegio.Models
{
    public class Curso
    {
        public Curso()
        {
            Estudiantes = new HashSet<Estudiante>();
            Materias = new HashSet<Materia>();
        }

        public int IdCurso { get; set; }
        public string Nombre { get; set; } = null!;
        public string Seccion { get; set; } = null!;


        public virtual ICollection<Estudiante> Estudiantes { get; set; }
        public virtual ICollection<Materia> Materias { get; set; }
    }





}


