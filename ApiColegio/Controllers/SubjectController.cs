using ApiColegio.Context;
using ApiColegio.Models;
using ApiColegio.Dtos.SubjectDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiColegio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        private readonly ConexionSQLServer context;

        public SubjectController(ConexionSQLServer context)
        {
            this.context = context;
        }
        // GET: api/<SubjectController>
        [HttpGet]
        public async Task<IEnumerable<SubjectToListDto>> Get()
        {
            var materia = context.Materias.Select(materia => new SubjectToListDto
            {
                Id=materia.IdMateria,
                Nombre=materia.Nombre,
                Profesor = materia.Profesor.Nombre +" "+ materia.Profesor.Apellido,
            }).AsEnumerable();
            return materia;
        }

        // GET api/<SubjectController>/5
        [HttpGet("{id}")]
        public async Task<IEnumerable<SubjectToListDto>> Get(int id)
        {
            var materia = context.Materias.Select(materia => new SubjectToListDto
            {
                Id = materia.IdMateria,
                Nombre = materia.Nombre,
                 Profesor= materia.Profesor.Nombre +" "+ materia.Profesor.Apellido,
            }).Where(x=>x.Id==id).AsEnumerable();
            return materia;
        }

        // POST api/<SubjectController>
        [HttpPost]
        public async Task<ActionResult<SubjectRegisterDto>> Post([FromBody] SubjectRegisterDto materia)
        {
            var materiaRegistered = new Materia
            {
                Nombre = materia.Nombre,
                Nivel= materia.Nivel,
                IdCurso=materia.IdCurso
            };
            try
            {
                context.Materias.Add(materiaRegistered);
                await context.SaveChangesAsync();
                return Ok(materiaRegistered);
            }
            catch (Exception)
            {
                return BadRequest("No se pudo registrar la materia");
            }
        }

        // PUT api/<SubjectController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<SubjectUpdateDto>> Put(int id, [FromBody] SubjectUpdateDto materia)
        {
            var materiaRegistered = new Materia
            {   IdMateria=materia.Id,
                Nombre = materia.Nombre,
                Nivel= materia.Nivel,
                IdCurso=materia.IdCurso
            };
                context.Materias.Update(materiaRegistered).State = EntityState.Modified;
            try
            {
                await context.SaveChangesAsync();
                return Ok(materiaRegistered);
            }
            catch (Exception)
            {
                return BadRequest("No se pudo actualizar la materia");
            }
        }

        // DELETE api/<SubjectController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Materia>> Delete(int id)
        {
            var materia = await context.Materias.FindAsync(id);
            if (materia != null)
            {
                context.Remove(materia);
                await context.SaveChangesAsync();
                return Ok(materia);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
