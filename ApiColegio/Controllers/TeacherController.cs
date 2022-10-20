using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiColegio.Dtos.TeacherDtos;
using ApiColegio.Context;
using ApiColegio.Models;
using System.Runtime.CompilerServices;

namespace ApiColegio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly ConexionSQLServer context;

        public TeacherController(ConexionSQLServer context)
        {
            this.context = context;
        }

        // GET: api/Teacher
        [HttpGet]
        public  Task<IEnumerable<TeacherToListDto>> Get()
        {
            var query = context.Teachers
                .Select(teacher => new TeacherToListDto
                {
                    Id = teacher.IdTeacher,
                    Name = teacher.FirstName + " " + teacher.LastName,
                    PhoneNumber = teacher.PhoneNumber,

                    Subject = teacher.Subject.Name
                }).AsEnumerable();
            return Task.FromResult(query);
        }

        // GET: api/Teacher/5
        [HttpGet("{id}")]
        public  Task<IEnumerable<TeacherToListDto>> Get(int id)
        {

            var query = context.Teachers.Select(
                teacher => new TeacherToListDto
                {
                    Id = teacher.IdTeacher,
                    Name = teacher.FirstName + " " + teacher.LastName,
                    PhoneNumber = teacher.PhoneNumber,

                    Subject = teacher.Subject.Name

                }).Where(x => x.Id == id).AsEnumerable();


            return Task.FromResult(query);

        }

        // PUT: api/Teacher/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, TeacherUpdateDto teacher)
        {
            if (id != teacher.Id)
            {
                return BadRequest();
            }
            // var profesorToUpdate = await context.Profesores.FindAsync(id);

            var profesorUpdate = new Teacher
            {
                IdTeacher = teacher.Id,
                FirstName = teacher.FirstName,
                LastName = teacher.LastName,
                PhoneNumber = teacher.PhoneNumber,
                IdSubject = teacher.IdSubject,
            };

            context.Update(profesorUpdate).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProfesorExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Teacher
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TeacherRegisterDto>> Post(TeacherRegisterDto profesor)
        {
            try
            {
                var profesorRegister = new Teacher
                {
                    // IdProfesor = profesor.IdProfesor,
                    FirstName = profesor.FirstName,
                    LastName = profesor.LastName,
                    Date = profesor.Date,
                    PhoneNumber = profesor.PhoneNumber,
                    IdSubject = profesor.IdSubject
                };
                context.Teachers.Add(profesorRegister);
                await context.SaveChangesAsync();
                return Ok(profesor);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // DELETE: api/Teacher/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var profesor = await context.Teachers.FindAsync(id);
            if (profesor == null)
            {
                return NotFound();
            }

            context.Teachers.Remove(profesor);
            await context.SaveChangesAsync();

            return Ok(profesor);
        }

        bool ProfesorExists(int id)
        {
            return context.Teachers.Any(e => e.IdTeacher == id);
        }
    }
}


