using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;

namespace ApiColegio.Models
{
    public class Profesores
    {
        public int IdProfesor { get; set; }
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public DateTime? FechaNacimiento { get; set; }
        public string Telefono { get; set; } = null!;
        public int IdMateria { get; set; }

        public virtual Materias Materia { get; set; } = null!;
    }
}
