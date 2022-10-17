namespace ApiColegio.Dtos.TeacherDtos
{
    public class TeacherUpdateDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public string Telefono { get; set; } = null!;
        public int IdMateria { get; set; }
    }
}
