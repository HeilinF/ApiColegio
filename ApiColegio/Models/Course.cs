using System.ComponentModel.DataAnnotations;

namespace ApiColegio.Models
{
    public class Course
    {
        public Course()
        {
            Students = new HashSet<Student>();
            Subjects = new HashSet<Subject>();
        }

        public int IdCourse { get; set; }
        public string Name { get; set; } = null!;
        public string Section { get; set; } = null!;


        public virtual ICollection<Student> Students { get; set; }
        public virtual ICollection<Subject> Subjects { get; set; }
    }





}


