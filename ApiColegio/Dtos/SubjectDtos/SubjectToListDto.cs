using ApiColegio.Models;

namespace ApiColegio.Dtos.SubjectDtos
{
    public class SubjectToListDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Profesor { get; set; } = null!;
    }
}
