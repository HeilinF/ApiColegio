using ApiColegio.Contexts;
using ApiColegio.Models;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiColegio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MateriasController : ControllerBase
    {

        private readonly ConexionSQLServer context;
        public MateriasController(ConexionSQLServer context)
        {
            this.context = context;
        }
        // GET: api/<MateriasController>
        [HttpGet]
        public async Task <IEnumerable<Materias>> Get()
        {
            return await context.Materias.Include(x=>x.Estudiantes).ToListAsync();
        }

        // GET api/<MateriasController>/5
        [HttpGet("{id}")]
        public Materias Get(int id)
        {
            var materia = context.Materias.FirstOrDefault(e => e.IdMateria == id);
            return materia;
        }

        // POST api/<MateriasController>
        [HttpPost]
        public ActionResult Post([FromBody] Materias materias)
        {
            try
            {
                context.Materias.Add(materias).GetDatabaseValues();
                context.SaveChanges();
                return Ok();

            }
            catch(Exception)
            {
                return BadRequest();
            }

        }

        // PUT api/<MateriasController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<MateriasController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
