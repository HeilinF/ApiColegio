using ApiColegio.Contexts;
using ApiColegio.Models;
using Microsoft.Data.SqlClient;

/* namespace ApiColegio.Data
{

    public class Conexion
    {
        public static string rutaconexion => "Data Source=LAPTOP-O2E6A0VL;Initial Catalog=Colegio;Integrated Security=True";
    }
    public class EstudiantesData
    {
      
        public static bool Registrar(Estudiantes estudiantes)
        {
            using SqlConnection oConectar = new SqlConnection(Conexion.rutaconexion);

            SqlCommand cmd = new SqlCommand("registrar", oConectar);
                cmd.CommandType= System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", estudiantes.id_estudiante = 0);
            cmd.Parameters.AddWithValue("@Nombre", estudiantes.nombre);
            cmd.Parameters.AddWithValue("@Apellido", estudiantes.apellido);
            cmd.Parameters.AddWithValue("@Fecha de Nacimiento", estudiantes.fecha_nacimiento);
            cmd.Parameters.AddWithValue("@Telefono", estudiantes.telefono);
            cmd.Parameters.AddWithValue("@Tutor", estudiantes.tutor);
            cmd.Parameters.AddWithValue("@Curso", estudiantes.id_curso);

            try
            {
                oConectar.Open();
                cmd.ExecuteNonQuery();
                return true;

            }
            catch (Exception)
            {
                return false;
            }


    
        }
    }
}*/
