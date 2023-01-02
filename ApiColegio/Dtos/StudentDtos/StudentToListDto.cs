using ApiColegio.Dtos.SubjectDtos;

namespace ApiColegio.Dtos.StudentDtos
{
    public class StudentToListDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public short Age { get; set; }
        public string? PhoneNumber { get; set; }
        public string Course { get; set; } = null!;
        public IEnumerable<SubjectToListDto>? Subjects { get; set; }

    }
}
