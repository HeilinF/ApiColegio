using ApiColegio.Dtos.SubjectDtos;

namespace ApiColegio.Dtos.CourseDtos
{
    public class CourseToListDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Section { get; set; } = null!;

           public IEnumerable<SubjectToListDto> Subjects { get; set; }
    }
}
