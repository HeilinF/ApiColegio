using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;

namespace ApiColegio.Models
{
    public class Profesores
    {
        [Key] public int id_profesor { get; set; }
    }
}
