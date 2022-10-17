namespace ApiColegio.Dtos.TeacherDtos
{
    public class TeacherRegisterDto
    {
       // public int IdProfesor { get; set; }
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public DateTime FechaNacimiento { get; set; }
        public string Telefono { get; set; } = null!;
        public int IdMateria { get; set; }
    }
}
