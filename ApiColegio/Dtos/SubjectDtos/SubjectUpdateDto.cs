namespace ApiColegio.Dtos.SubjectDtos
{
    public class SubjectUpdateDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
     //   public string Level { get; set; } = null!;
        public int IdCourse { get; set; }

    }
}
