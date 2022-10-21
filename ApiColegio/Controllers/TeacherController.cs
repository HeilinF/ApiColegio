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

                }).Where(x => x.Id == id)
                .AsEnumerable();


            return Task.FromResult(query);

        }

        // PUT: api/Teacher/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, TeacherUpdateDto teacher)
        {
            if (!TeacherExists(id))  return NotFound();
            

            var teacherUpdated = new Teacher
            {
                IdTeacher = teacher.Id,
                FirstName = teacher.FirstName,
                LastName = teacher.LastName,
                PhoneNumber = teacher.PhoneNumber,
                IdSubject = teacher.IdSubject,
            };

            try
            { 
                context.Update(teacherUpdated).State = EntityState.Modified;
                await context.SaveChangesAsync();
                return Ok(teacherUpdated);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TeacherExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
        }

        // POST: api/Teacher
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TeacherRegisterDto>> Post(TeacherRegisterDto teacher)
        {
            try
            {
                var teacherRegistered = new Teacher
                {
                    // IdProfesor = profesor.IdProfesor,
                    FirstName = teacher.FirstName,
                    LastName = teacher.LastName,
                    Date = teacher.Date,
                    PhoneNumber = teacher.PhoneNumber,
                    IdSubject = teacher.IdSubject
                };
                context.Teachers.Add(teacherRegistered);
                await context.SaveChangesAsync();
                return Ok(teacher);
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
            var teacher = await context.Teachers.FindAsync(id);
            if (teacher == null)
            {
                return NotFound();
            }

            context.Teachers.Remove(teacher);
            await context.SaveChangesAsync();

            return Ok(teacher);
        }

        bool TeacherExists(int id)
        {
            return context.Teachers.Any(e => e.IdTeacher == id);
        }
    }
}


