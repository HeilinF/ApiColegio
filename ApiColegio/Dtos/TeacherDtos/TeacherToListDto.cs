namespace ApiColegio.Dtos.TeacherDtos
{
    public class TeacherToListDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;

        public string Subject { get; set; } = null!;


    }
}
