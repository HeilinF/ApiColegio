namespace ApiColegio.Dtos.TeacherDtos
{
    public class TeacherUpdateDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public int IdSubject { get; set; }
    }
}
