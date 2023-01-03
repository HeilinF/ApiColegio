using ApiColegio.Dtos.SubjectDtos;

namespace Application.Dtos.CourseDtos
{
    public class CourseResponse
    {
        public string Name { get; set; } 
        public string Section { get; set; }
    }

    public class CourseToListDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Section { get; set; } = null!;

           public IEnumerable<SubjectToListDto> Subjects { get; set; }
    }
}
