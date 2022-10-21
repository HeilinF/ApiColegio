namespace ApiColegio.Models
{
    public class Grade
    {
      //  public int IdGrade { get; set; }
        public int IdStudent { get; set; }

        public virtual Student Student { get; set; } = null!;

        public int IdSubject { get; set; }

        public virtual Subject Subject { get; set; } = null!;

        public int Qualification { get; set; }
    }
}
