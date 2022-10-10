using ApiColegio.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiColegio.Contexts
{
    public class ConexionSQLServer: DbContext
    {
        public ConexionSQLServer(DbContextOptions<ConexionSQLServer> options): base(options)
        {

        }
        public DbSet<Estudiantes> Estudiantes { get; set; } 
    }
}
