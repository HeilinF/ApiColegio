namespace ApiColegio.Dtos.StudentDtos
{
    public class StudentRegisterDto
    {

        public readonly int Id;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public DateTime Date { get; set; }
        public string? PhoneNumber { get; set; }
        public string Tutor { get; set; }= null!;
        public int IdCourse { get; set; }
        
    }
}
