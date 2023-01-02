using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography;

namespace Domain.Entities.Models
{
    public class Teacher: EntityBase
    {

        //   public int IdTeacher { get; set; }

        [Column("Nombre")]
        public string FirstName { get; set; } = null!;
        [Column("Apellido")]
        public string LastName { get; set; } = null!;
        [Column("FechaDeNacimiento")]
        public DateTime? Date { get; set; }
        [Column("NumeroDeTelefono")]
        public string PhoneNumber { get; set; } = null!;
        [Column("MateriaId"), ForeignKey("FK_Profesores_Materias")]
        public int IdSubject { get; set; }
        public virtual Subject Subject { get; set; } = null!;
    }
}
