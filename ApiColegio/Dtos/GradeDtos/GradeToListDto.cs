using ApiColegio.Dtos.SubjectDtos;
using ApiColegio.Models;

namespace ApiColegio.Dtos.GradeDtos
{
    public class GradeToListDto
    {
       public Student Student { get; set; } 
        public  IEnumerable<SubjectGradeToList> Record { get; set; } = null!;

       // public IEnumerable<Subject> Subject { get; set; } = null!;

    }
}
