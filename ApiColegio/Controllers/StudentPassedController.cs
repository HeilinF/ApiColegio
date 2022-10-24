using ApiColegio.Context;
using ApiColegio.Dtos.StudentDtos;
using ApiColegio.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiColegio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentPassedController : ControllerBase
    {
        private readonly ConexionSQLServer context;

        public StudentPassedController(ConexionSQLServer context)
        {
            this.context = context;
        }
        // GET: api/<StudentPassedController>
        [HttpGet]
        public Task<IEnumerable<StudentCoursePassedDto>> Get()
        {
            var Query = context.Courses.Select(course => new StudentCoursePassedDto
            {
                IdCourse = course.IdCourse,
                Name = course.Name,
                Passed = IsPassed(),
                Student= course.Students.Select(student=> new StudentPassedDto
                {
                    Name= student.FirstName,
                    PhoneNumber=student.PhoneNumber,
                    Average= context.Grades
                    .Where(x => x.IdStudent
                    == student.IdStudent).Select(x => x.FirstPartial).
                    Sum()/(student.Course.Subjects.Count),

                })

            }).AsEnumerable();

                return Task.FromResult(Query);
        }

        // GET api/<StudentPassedController>/5
        [HttpGet("{idCourse}")]
        public string Get(int idCourse)
        {
            return "value";
        }
        bool IsPassed()
        {
            var student = new StudentPassedController(context);
            if ( student.GetAverage() >= 6)
                return true;

            else { return false; }
        }
        
        double GetAverage()
        {
          double Average = context.Grades
            .Where(x => x.IdStudent
                 == x.Student.IdStudent).Select(x => x.FirstPartial).Sum() /6;

            return Average;
        }


    }
}
