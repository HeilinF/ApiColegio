namespace ApiColegio.Dtos.StudentDtos
{
    public class StudentUpdateDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public DateTime FechaNacimiento { get; set; }
        public string? Telefono { get; set; }
        public string Tutor { get; set; } = null!;
        public int IdCurso { get; set; }
    }
}
