using ApiColegio.Dtos.GradeDtos;
using Domain.Context;
using Domain.Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiColegio.Controllers.GradeController
{
    [Route("api/[controller]")]
    [ApiController]
    public class GradeController : ControllerBase
    {
        private readonly ConexionSQLServer context;

        public GradeController(ConexionSQLServer context)
        {
            this.context = context;
        }
        // GET: api/<GradeController>
        [HttpGet]
        public Task<IEnumerable<StudentGradeToListDto>> Get()
        {

            var query = context.Students.Select(student => new StudentGradeToListDto
            {
                Id = student.Id,
                Name = student.FirstName + " " + student.LastName,
                // Age = (short)Math.Floor((DateTime.Now - student.Date).TotalDays / 365),
                PhoneNumber = student.PhoneNumber,
                Course = student.Course.Name + " " + student.Course.Section,

                Record = context.Grades
                .Where(x => x.IdStudent == student.Id)
                .Select(subject => new SubjectGradeToListDto
                {
                    Id = subject.IdSubject,
                    Subject = subject.Subject.Name,
                    // Teacher= subject.Subject.Teacher.FirstName +" "+ subject.Subject.Teacher.LastName,
                    FirstPartial = subject.FirstPartial,
                    //SecondPartial = subject.SecondPartial,
                    //ThirdPartial = subject.ThirdPartial


                }).ToList()

            }).AsEnumerable();

            return Task.FromResult(query);

        }

        // GET api/<GradeController>/5
        [HttpGet("{idstudent}")]
        public Task<IEnumerable<StudentGradeToListDto>> Get(int idstudent)
        {

            var query = context.Students.Select(student => new StudentGradeToListDto
            {
                Id = student.Id,
                Name = student.FirstName + " " + student.LastName,
                // Age = (short)Math.Floor((DateTime.Now - student.Date).TotalDays / 365),
                PhoneNumber = student.PhoneNumber,
                Course = student.Course.Name + " " + student.Course.Section,

                Record = context.Grades
                .Where(x => x.IdStudent == student.Id)
                .Select(subject => new SubjectGradeToListDto
                {
                    Subject = subject.Subject.Name,
                    // Teacher = subject.Subject.Teacher.FirstName + " " + subject.Subject.Teacher.LastName,
                    FirstPartial = subject.FirstPartial,
                    //SecondPartial = subject.SecondPartial,
                    //ThirdPartial = subject.ThirdPartial

                }).ToList()

            }).Where(x => x.Id == idstudent).AsEnumerable();

            return Task.FromResult(query);

        }
        // POST api/<GradeController>
        [HttpPost("First")]
        public async Task<ActionResult<FirstGradeRegisterDto>> Post([FromBody] FirstGradeRegisterDto grade)
        {
            var gradeRegistered = new Grade
            {
                IdStudent = grade.IdStudent,
                IdSubject = grade.IdSubject,
                FirstPartial = grade.FirstPartial,
            };

            try
            {
                context.Add(gradeRegistered);
                await context.SaveChangesAsync();
                return Ok(grade);
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }
        //[HttpPost("Second")]
        //public async Task<ActionResult<SecondGradeRegisterDto>> Post([FromBody] SecondGradeRegisterDto grade)
        //{
        //    var gradeRegistered = context.Grades.Select(grade => new SecondGradeRegisterDto
        //    {
        //        IdStudent = grade.IdStudent,
        //        IdSubject = grade.IdSubject,
        //        SecondPartial = grade.SecondPartial,
        //    });

        //    try
        //    {
        //        context.Add(gradeRegistered);
        //        await context.SaveChangesAsync();
        //        return Ok(grade);
        //    }
        //    catch (Exception)
        //    {
        //        return BadRequest();
        //    }

        //}

        // PUT api/<GradeController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<FirstGradeRegisterDto>> Put(int id, [FromBody] FirstGradeRegisterDto grade)
        {
            var gradeRegistered = new Grade
            {
                IdStudent = grade.IdStudent,
                IdSubject = grade.IdSubject,
                FirstPartial = grade.FirstPartial
                // SecondPartial = grade.SecondPartial,
            };

            try
            {
                context.Update(gradeRegistered).State = EntityState.Modified;
                await context.SaveChangesAsync();
                return Ok(grade);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        //// DELETE api/<GradeController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
