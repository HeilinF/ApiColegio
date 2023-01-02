using ApiColegio.Dtos.SubjectDtos;

namespace ApiColegio.Dtos.GradeDtos
{
    public class SubjectGradeToListDto
    {
        public int Id { get; set; }
        public string Subject { get; set; } = null!;
        //  public string Teacher { get; set; } = null!;

        public int FirstPartial { get; set; }
        //public int? SecondPartial { get; set; }
        //public int? ThirdPartial { get; set; }

    }
}