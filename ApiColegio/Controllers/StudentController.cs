using ApiColegio.Context;
using ApiColegio.Dtos.StudentDtos;
using ApiColegio.Dtos.SubjectDtos;
using ApiColegio.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiColegio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly ConexionSQLServer context;

        public StudentController(ConexionSQLServer context)
        {
            this.context = context;
        }
        // GET: api/<StudentController>
        [HttpGet]
        public async Task<IEnumerable<StudentToListDto>> Get()
        {
            var query = context.Estudiantes
               .Select(student => new StudentToListDto
               {
                   Id = student.IdEstudiante,
                   Name = student.Nombre + " " + student.Apellido,
                   Age = (short)Math.Floor((DateTime.Now - student.FechaNacimiento).TotalDays / 365),
                   PhoneNumber = student.Telefono,
                   IdCurso=student.IdCurso,

                   Grade = student.Curso.Materias.Select(materia=> new SubjectToListDto
                   {
                       Id=materia.IdMateria,
                       Nombre= materia.Nombre,

                       Profesor = materia.Profesor.Nombre +" "+ materia.Profesor.Apellido

                   })
                   
               }).AsEnumerable();
            return query;
            
        }

        // GET api/<StudentController>/5
        [HttpGet("{id}")]
        public  async Task<IEnumerable<StudentToListDto>> Get(int id)
        {
            var query =  context.Estudiantes
               .Select(student => new StudentToListDto
               {
                   Id = student.IdEstudiante,
                   Name = student.Nombre + " " + student.Apellido,
                   Age = (short)Math.Floor((DateTime.Now - student.FechaNacimiento).TotalDays / 365),
                   PhoneNumber = student.Telefono,
                   IdCurso= student.IdCurso,

                   Grade = student.Curso.Materias.Select(materia => new SubjectToListDto
                   {
                       Id = materia.IdMateria,
                       Nombre = materia.Nombre,

                       Profesor = materia.Profesor.Nombre + " " + materia.Profesor.Apellido

                   })

               }).Where(x=>x.Id==id).AsEnumerable();
            return query;
        }

        // POST api/<StudentController>
        [HttpPost]
        public async Task<ActionResult<StudentRegisterDto>> Post([FromBody] StudentRegisterDto estudiante)
        {
            var estudianteRegistered = new Estudiante
            {
                Nombre = estudiante.Nombre,
                Apellido = estudiante.Apellido,
                FechaNacimiento = estudiante.FechaNacimiento,
                Telefono =estudiante.Telefono,
                Tutor= estudiante.Tutor,
                IdCurso= estudiante.IdCurso,
            };
         
            context.Estudiantes.Add(estudianteRegistered);

            try
            {
                await context.SaveChangesAsync();
                return Ok(estudianteRegistered);
            }
            catch (Exception)
            {
                return BadRequest("Error Inesperado");
            }
        }

        // PUT api/<StudentController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<StudentUpdateDto>> Put
            (int id, [FromBody] StudentUpdateDto estudiante)
        {
            if (id != estudiante.Id)
            {
                return BadRequest("Los Id no coinciden");
            }
            var estudianteUpdated = new Estudiante
            {   
                IdEstudiante=estudiante.Id,
                Nombre = estudiante.Nombre,
                Apellido = estudiante.Apellido,
                FechaNacimiento = estudiante.FechaNacimiento,
                Telefono = estudiante.Telefono,
                Tutor=estudiante.Tutor,
                IdCurso=estudiante.IdCurso,
            };
                  
                context.Update(estudianteUpdated).State= EntityState.Modified;

               try 
               {
                await context.SaveChangesAsync();
                return Ok(estudianteUpdated);
               }
            catch (Exception)
            {
                return BadRequest();
            }

        }

        // DELETE api/<StudentController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Estudiante>> Delete(int id)
        {
            var estudiante= await context.Estudiantes.FindAsync(id);
            if (estudiante != null)
            {
                context.Remove(estudiante);
               await context.SaveChangesAsync();
                return Ok(estudiante);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
