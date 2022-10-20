using ApiColegio.Context;
using ApiColegio.Dtos.CourseDtos;
using ApiColegio.Dtos.SubjectDtos;
using ApiColegio.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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

                /*Subjects = context.Subjects.Select(subject => new SubjectToListDto
                {
                    Id = subject.IdSubject,
                    Name = subject.Name,
                    Teacher = subject.Teacher.FirstName + " " + subject.Teacher.LastName
                }).AsEnumerable()*/
                Subjects= course.Subjects.Select(x=>x.Name)

            }).AsEnumerable();

            return Task.FromResult(query);
        }

        // GET api/<CourseController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CourseController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CourseController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CourseController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
