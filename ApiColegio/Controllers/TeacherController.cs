using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiColegio.Dtos.TeacherDtos;
using ApiColegio.Context;
using ApiColegio.Models;

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
        public async Task<IEnumerable<TeacherToListDto>> Get()
        {
            var query = context.Profesores
                .Select(teacher => new TeacherToListDto
                {
                    Id = teacher.IdProfesor,
                    Name = teacher.Nombre + " " + teacher.Apellido,
                    PhoneNumber = teacher.Telefono,

                    Subject = teacher.Materia.Nombre
                }).AsEnumerable();
            return query;
        }

        // GET: api/Teacher/5
        [HttpGet("{id}")]
        public async Task<IEnumerable<TeacherToListDto>> Get(int id)
        {

            var query = context.Profesores.Select(
                teacher => new TeacherToListDto
                {
                    Id = teacher.IdProfesor,
                    Name = teacher.Nombre + " " + teacher.Apellido,
                    PhoneNumber = teacher.Telefono,

                    Subject = teacher.Materia.Nombre

                }).Where(x => x.Id == id).AsEnumerable();


            return query;

        }

        // PUT: api/Teacher/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, TeacherUpdateDto profesor)
        {
            if (id != profesor.Id)
            {
                return BadRequest();
            }
            // var profesorToUpdate = await context.Profesores.FindAsync(id);

            var profesorUpdate = new Profesor
            {
                IdProfesor = profesor.Id,
                Nombre = profesor.Nombre,
                Apellido = profesor.Apellido,
                Telefono = profesor.Telefono,
                IdMateria = profesor.IdMateria,
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
                var profesorRegister = new Profesor
                {
                    // IdProfesor = profesor.IdProfesor,
                    Nombre = profesor.Nombre,
                    Apellido = profesor.Apellido,
                    FechaNacimiento = profesor.FechaNacimiento,
                    Telefono = profesor.Telefono,
                    IdMateria = profesor.IdMateria
                };
                context.Profesores.Add(profesorRegister);
                await context.SaveChangesAsync();
                return Ok(profesorRegister);
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
            var profesor = await context.Profesores.FindAsync(id);
            if (profesor == null)
            {
                return NotFound();
            }

            context.Profesores.Remove(profesor);
            await context.SaveChangesAsync();

            return NoContent();
        }

        bool ProfesorExists(int id)
        {
            return context.Profesores.Any(e => e.IdProfesor == id);
        }
    }
}


