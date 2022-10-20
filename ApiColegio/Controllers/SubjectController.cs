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
        public  Task<IEnumerable<SubjectToListDto>> Get()
        {
            var subject = context.Subjects.Select(subject => new SubjectToListDto
            {
                Id=subject.IdSubject,
                Name =subject.Name,
                Teacher = subject.Teacher.FirstName +" "+ subject.Teacher.LastName,
            }).AsEnumerable();
            return Task.FromResult(subject);
        }

        // GET api/<SubjectController>/5
        [HttpGet("{id}")]
        public  Task<IEnumerable<SubjectToListDto>> Get(int id)
        {
            var subject = context.Subjects.Select(materia => new SubjectToListDto
            {
                Id = materia.IdSubject,
                Name = materia.Name,
                 Teacher = materia.Teacher.FirstName +" "+ materia.Teacher.LastName,
            }).Where(x=>x.Id==id).AsEnumerable();
            return Task.FromResult(subject);
        }

        // POST api/<SubjectController>
        [HttpPost]
        public async Task<ActionResult<SubjectRegisterDto>> Post([FromBody] SubjectRegisterDto materia)
        {
            var materiaRegistered = new Subject
            {
                Name = materia.Name,
               // Level = materia.Level,
                IdCourse =materia.IdCourse
            };
            try
            {
                context.Subjects.Add(materiaRegistered);
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
        public async Task<ActionResult<SubjectUpdateDto>> Put(int id, [FromBody] SubjectUpdateDto subject)
        {

            if (id != subject.Id) { return NotFound(); }
            else
            {
                var materiaRegistered = new Subject
                {
                    IdSubject = subject.Id,
                    Name = subject.Name,
                   // Level = subject.Level,
                    IdCourse = subject.IdCourse
                };
                context.Subjects.Update(materiaRegistered).State = EntityState.Modified;
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
        }

        // DELETE api/<SubjectController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Subject>> Delete(int id)
        {
            var materia = await context.Subjects.FindAsync(id);
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
