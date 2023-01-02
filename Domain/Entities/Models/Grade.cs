using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.Models
{
    [Table("Notas")]
    public class Grade
    {
        //  public int IdGrade { get; set; 
        [Column("IdEstudiante"), ForeignKey("FK_Grades_Students")]
        public int IdStudent { get; set; }

        public virtual Student Student { get; set; } = null!;
        [Column("IdMateria"),ForeignKey("FK_Grades_Subjects")]
        public int IdSubject { get; set; }

        public virtual Subject Subject { get; set; } = null!;
        [Column("PrimerParcial")]
        public int FirstPartial { get; set; }
        //public int? SecondPartial { get; set; }
        //public int? ThirdPartial { get; set; }
    }
}
