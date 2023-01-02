using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.Models
{
    [Table("Curso")]
    public class Course: EntityBase
    {
    //    public Course()
    //    {
    //        Students = new HashSet<Student>();
    //        Subjects = new HashSet<Subject>();
    //    }

        [Column("Nombre")]
        public string Name { get; set; } = null!;
        [Column("Seccion")]
        public string Section { get; set; } = null!;


        public virtual ICollection<Student> Students { get; set; }
        public virtual ICollection<Subject> Subjects { get; set; }
    }





}


