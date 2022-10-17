namespace ApiColegio.Dtos.SubjectDtos
{
    public class SubjectUpdateDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Nivel { get; set; } = null!;
        public int IdCurso { get; set; }

    }
}
