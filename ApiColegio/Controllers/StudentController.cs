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
        public Task<IEnumerable<StudentToListDto>> Get()
        {
            var query =  context.Students
               .Select(student => new StudentToListDto
               {
                   Id = student.IdStudent,
                   Name = student.FirstName + " " + student.LastName,
                   Age = (short)Math.Floor((DateTime.Now - student.Date).TotalDays / 365),
                   PhoneNumber = student.PhoneNumber,
                   Course =student.Course.Name +" "+ student.Course.Section,

                   Subjects = student.Course.Subjects.Select(subject=> new SubjectToListDto
                   {
                       Id=subject.IdSubject,
                       Name= subject.Name,

                       Teacher = subject.Teacher.FirstName +" "+ subject.Teacher.LastName

                   })
                   
               }).AsEnumerable();
            return Task.FromResult(query);
            
        }

        // GET api/<StudentController>/5
        [HttpGet("{id}")]
        public  Task<IEnumerable<StudentToListDto>> Get(int id)
        {
            var query =  context.Students
               .Select(student => new StudentToListDto
               {
                   Id = student.IdStudent,
                   Name = student.FirstName + " " + student.LastName,
                   Age = (short)Math.Floor((DateTime.Now - student.Date).TotalDays / 365),
                   PhoneNumber = student.PhoneNumber,
                   Course = student.Course.Name + " " + student.Course.Section,

                   Subjects = student.Course.Subjects.Select(subject => new SubjectToListDto
                   {
                       Id = subject.IdSubject,
                       Name = subject.Name,

                       Teacher = subject.Teacher.FirstName + " " + subject.Teacher.LastName

                   })

               }).Where(x=>x.Id==id)
               .AsEnumerable();
            return Task.FromResult(query);
        }

        // POST api/<StudentController>
        [HttpPost]
        public async Task<ActionResult<StudentRegisterDto>> Post
            ([FromBody] StudentRegisterDto student)
        {
            var studentRegistered = new Student
            {
                FirstName = student.FirstName,
                LastName = student.LastName,
                Date = student.Date,
                PhoneNumber =student.PhoneNumber,
                Tutor= student.Tutor,
                IdCourse= student.IdCourse,
            };
         
            context.Students.Add(studentRegistered);

            try
            {
                await context.SaveChangesAsync();
                return Ok(studentRegistered);
            }
            catch (Exception)
            {
                return BadRequest("Error Inesperado");
            }
        }

        // PUT api/<StudentController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<StudentUpdateDto>> Put
            (int id, [FromBody] StudentUpdateDto student)
        {
            if (id != student.Id)
            {
                return BadRequest("Los Id no coinciden");
            }
            var studentUpdated = new Student
            {   
                IdStudent =student.Id,
                FirstName = student.FirstName,
                LastName = student.LastName,
                Date = student.Date,
                PhoneNumber = student.PhoneNumber,
                Tutor= student.Tutor,
                IdCourse = student.IdCourse,
            };
                  
                context.Update(studentUpdated).State= EntityState.Modified;

               try 
               {
                await context.SaveChangesAsync();
                return Ok(studentUpdated);
               }
            catch (Exception)
            {
                return BadRequest();
            }

        }

        // DELETE api/<StudentController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Student>> Delete(int id)
        {
            var student= await context.Students.FindAsync(id);
            if (student != null)
            {
                context.Remove(student);
               await context.SaveChangesAsync();
                return Ok(student);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
