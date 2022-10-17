using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ServiceStack.DataAnnotations;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;

namespace ApiColegio.Models
{
    public class Estudiante
    {
      /*  public Student()
        {
           Materias= new HashSet<Subject>();
         
        }  */
        public int IdEstudiante { get; set; }
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; }= null!;
        public DateTime FechaNacimiento { get; set; }
        public string? Telefono { get; set; }
        public string? Tutor { get; set; } = null!;
        public int IdCurso { get; set; }
        public virtual Curso Curso { get; set; } = null!;
     // public virtual ICollection<Subject> Materias { get;}

    }
}
