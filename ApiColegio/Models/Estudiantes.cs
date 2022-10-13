using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ServiceStack.DataAnnotations;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;

namespace ApiColegio.Models
{
    public class Estudiantes
    {
        public Estudiantes()
        {
           Materias= new HashSet<Materias>();
            var i = Materias;
        }
        [Key] public int IdEstudiante { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string? Telefono { get; set; }
        public string? Tutor { get; set; }

        public virtual ICollection<Materias> Materias { get; set; }



        // public int IdCurso { get; set; }

        // public virtual Materias  Curso { get; set; }


    }
}
