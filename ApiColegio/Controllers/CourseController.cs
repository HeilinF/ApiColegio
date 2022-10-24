using ApiColegio.Context;
using ApiColegio.Dtos.CourseDtos;
using ApiColegio.Dtos.SubjectDtos;
using ApiColegio.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiColegio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase

    {
        private readonly ConexionSQLServer context;

        public CourseController(ConexionSQLServer context)
        {
            this.context = context;
        }
        // GET: api/<CourseController>
        [HttpGet]
        public Task<IEnumerable<CourseToListDto>> Get()
        {
            var query = context.Courses.Select(course => new CourseToListDto
            {
                Id = course.IdCourse,
                Name = course.Name,
                Section = course.Section,

                Subjects = course.Subjects.Select(subject => new SubjectToListDto
                {
                    Id = subject.IdSubject,
                    Name = subject.Name,
                    Teacher = subject.Teacher.FirstName + " " + subject.Teacher.LastName
                }).AsEnumerable()


            }).AsEnumerable();

            return Task.FromResult(query);
        }

        // GET api/<CourseController>/5
        [HttpGet("{id}")]
        public Task<IEnumerable<CourseToListDto>> Get(int id)
        {
            var query = context.Courses
                 .Where(x => x.IdCourse == id)
                .Select(course => new CourseToListDto
                {
                    Id = course.IdCourse,
                    Name = course.Name,
                    Section = course.Section,

                    Subjects = course.Subjects.Select(subject => new SubjectToListDto
                    {
                        Id = subject.IdSubject,
                        Name = subject.Name,
                        Teacher = subject.Teacher.FirstName + " " + subject.Teacher.LastName
                    }).AsEnumerable()


                }).AsEnumerable();

            return Task.FromResult(query);
        }

        // POST api/<CourseController>
        [HttpPost]
        public async Task<ActionResult<CourseRegisterDto>> Post([FromBody]CourseRegisterDto course)
        {
            var CourseRegistered = new Course
            {
                Name = course.Name,
                Section = course.Section,
            };
            try
            {
                context.Courses.Add(CourseRegistered);
               await context.SaveChangesAsync();
                return Ok(CourseRegistered);
            }
            catch(Exception)
            {
                return BadRequest();
            }
        }

        //// PUT api/<CourseController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{

        //}

        //// DELETE api/<CourseController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{

        //}
    }
}
