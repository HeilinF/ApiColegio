using ApiColegio.Contexts;
using ApiColegio.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
            try
            {
                context.Estudiantes.Add(estudiantes);
                context.SaveChanges();
                return Ok();// CreatedAtAction("GetEstudiante", new { id = estudiantes.id_estudiante }, estudiantes); ;
            }
            catch (Exception)
            {
                return BadRequest(":(");            }
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Estudiantes estudiantes)
        {
            if (estudiantes.id_estudiante == id)
            {
                context.Entry(estudiantes).State=EntityState.Modified;
                context.SaveChanges();
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            try
            {
                context.Estudiantes.Remove(Get(id));
                context.SaveChanges();
                return true;

            }
            catch( Exception)
            {
                return false;
                
            }
           


        }
    }
}
