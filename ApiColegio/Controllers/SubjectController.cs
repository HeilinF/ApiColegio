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
            var subject = context.Subjects.Select(subject => new SubjectToListDto
            {
                Id = subject.IdSubject,
                Name = subject.Name,
                 Teacher = subject.Teacher.FirstName +" "+ subject.Teacher.LastName,
            }).Where(x=>x.Id==id).AsEnumerable();
            return Task.FromResult(subject);
        }

        // POST api/<SubjectController>
        [HttpPost]
        public async Task<ActionResult<SubjectRegisterDto>> Post([FromBody] SubjectRegisterDto subject)
        {
            var subjectRegistered = new Subject
            {
                Name = subject.Name,
               // Level = materia.Level,
                IdCourse =subject.IdCourse
            };
            try
            {
                context.Subjects.Add(subjectRegistered);
                await context.SaveChangesAsync();
                return Ok(subjectRegistered);
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
                var subjectUpdated = new Subject
                {
                    IdSubject = subject.Id,
                    Name = subject.Name,
                   // Level = subject.Level,
                    IdCourse = subject.IdCourse
                };
                context.Subjects.Update(subjectUpdated).State = EntityState.Modified;
                try
                {
                    await context.SaveChangesAsync();
                    return Ok(subjectUpdated);
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
            var subject = await context.Subjects.FindAsync(id);
            if (subject != null)
            {
                context.Remove(subject);
                await context.SaveChangesAsync();
                return Ok(subject);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
