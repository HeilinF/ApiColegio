using ApiColegio.Models;

namespace ApiColegio.Dtos.SubjectDtos
{
    public class SubjectToListDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Teacher { get; set; } = null!;
    }
}
