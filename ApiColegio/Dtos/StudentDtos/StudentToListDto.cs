using ApiColegio.Dtos.SubjectDtos;
using ApiColegio.Models;

namespace ApiColegio.Dtos.StudentDtos
{
    public class StudentToListDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public short Age { get; set; }
        public string? PhoneNumber { get; set; }
        public int IdCurso { get; set; }
        public IEnumerable<SubjectToListDto> Grade { get; set; }

    }
}
