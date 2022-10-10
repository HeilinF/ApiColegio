using ApiColegio.Contexts;
using ApiColegio.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiColegio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstudiantesController : ControllerBase
    {
        private readonly ConexionSQLServer context;
        public EstudiantesController(ConexionSQLServer context)
        {
            this.context = context;
        }
        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<Estudiantes> Get() //Hecho
        {
            return context.Estudiantes.ToList();
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public Estudiantes Get(int id)
        {
            var estudiante = context.Estudiantes.FirstOrDefault(e => e.id_estudiante == id);
            return estudiante;
        }

        // POST api/<ValuesController>
        [HttpPost]
        public ActionResult Post( Estudiantes estudiantes)  //Hecho
        {
            context.Estudiantes.Add(estudiantes);
            context.SaveChanges();

            return Ok();
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
