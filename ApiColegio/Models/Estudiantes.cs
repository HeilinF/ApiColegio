using Microsoft.AspNetCore.Identity;
using ServiceStack.DataAnnotations;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;

namespace ApiColegio.Models
{
    public class Estudiantes
    {
        [Key]
        public int id_estudiante { get; set; }
        public string? nombre { get; set; }
        public string? apellido { get; set; }
        public DateTime fecha_nacimiento { get; set; }
        public string? telefono { get; set; }
        public string? tutor { get; set; }
        public int id_curso { get; set; }

        /*  public override bool Equals(object? obj)
          {
              return obj is Estudiantes estudiantes &&
                     id_curso == estudiantes.id_curso;
          }

          public override int GetHashCode()
          {
              return HashCode.Combine(id_curso);
          
      }*/
    }
}
