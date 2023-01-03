
using ApiColegio.Dtos.SubjectDtos;
using Application.Dtos.CourseDtos;

namespace Application.Dtos.StudentDtos
{
    public class StudentResponse
    {
        public int StudentId { get; set; }
        public string Name { get; set; } = null!;
        public short Age { get; set; }
        public string? PhoneNumber { get; set; }
        public CourseResponse Course { get; set; } = null!;
      //  public IEnumerable<SubjectToListDto>? Subjects { get; set; }

    }
}
