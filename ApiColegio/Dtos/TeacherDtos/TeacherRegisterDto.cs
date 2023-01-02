

namespace ApiColegio.Dtos.TeacherDtos
{
    public class TeacherRegisterDto
    {
       // public int IdProfesor { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public DateTime Date { get; set; }
        public string PhoneNumber { get; set; } = null!;
        public int IdSubject { get; set; }

       // public readonly Materia materia = null!;
    }
}
