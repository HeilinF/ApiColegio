using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ServiceStack.DataAnnotations;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;

namespace ApiColegio.Models
{
    public class Student
    {
       public Student()
        {
            // Materias= new HashSet<Subject>();
            Grades = new HashSet<Grade>();          
        }  
        public int IdStudent { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; }= null!;
        public DateTime Date { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Tutor { get; set; } = null!;
        public int IdCourse { get; set; }
        public virtual Course Course { get; set; } = null!;
       
     // public virtual ICollection<Subject> Materias { get;}

        public virtual ICollection<Grade> Grades { get; set; }
    }
}
