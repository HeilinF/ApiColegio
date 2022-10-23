using ApiColegio.Dtos.SubjectDtos;

namespace ApiColegio.Dtos.GradeDtos
{
    public class StudentGradeToListDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? PhoneNumber { get; set; }
        public string Course { get; set; } = null!;
        public IEnumerable<SubjectGradeToListDto>? Record { get; set; }
    }
}
