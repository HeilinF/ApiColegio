using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;

namespace ApiColegio.Models
{
    public class Teacher
    {
        public int IdTeacher { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public DateTime? Date { get; set; }
        public string PhoneNumber { get; set; } = null!;
        public int IdSubject { get; set; }
        public virtual Subject Subject { get; set; } = null!;
    }
}
