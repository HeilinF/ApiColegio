using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Domain.Entities.Models
{
    [Table("Estudiante")]
    public class Student: EntityBase
    {
        //public Student()
        //{
        //    // Materias= new HashSet<Subject>();
        //    Grades = new HashSet<Grade>();
        //}
        [Column("Nombre")]
        public string FirstName { get; set; } = null!;
        [Column("Apellido")]
        public string LastName { get; set; } = null!;
        [Column("FechaDeNacimiento")]
        public DateTime Date { get; set; }
        [Column("NumeroDeTelefono")]
        public string? PhoneNumber { get; set; }
        [Column("TutorLegal")]
        public string? Tutor { get; set; } = null!;
        [Column("IdCurso"), ForeignKey("FK_Estudiantes_Cursos")]
        public int IdCourse { get; set; }
        public virtual Course Course { get; set; } = null!;

        // public virtual ICollection<Subject> Materias { get;}

        public virtual ICollection<Grade> Grades { get; set; }

        public virtual short Age => (short)Math.Floor((DateTime.Now - Date).TotalDays / 365);

        public string NameBuilder()
        {
            var Name = new StringBuilder();
            Name.Append(FirstName);
            Name.Append(' ');
            Name.Append(LastName);

            return Name.ToString();
        }


    }
}
