using ApiColegio.Dtos.StudentDtos;
using Domain.Context;
using Microsoft.AspNetCore.Mvc;

namespace ApiColegio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentNonPassedController:ControllerBase
    {
        private readonly ConexionSQLServer context;
        public StudentNonPassedController(ConexionSQLServer context)
        {
            this.context= context;
        }


        [HttpGet]
        public Task<IEnumerable<StudentCoursePassedDto>> Get()
        {
            var Query = context.Courses.Select(course => new StudentCoursePassedDto
            {
                IdCourse = course.Id,
                Name = course.Name,

                Student = course.Students.Select(student => new StudentPassedDto
                {

                    Name = student.FirstName + " " + student.LastName,
                    PhoneNumber = student.PhoneNumber,
                    Average = context.Grades //Promedio total de los estudiantes
                    .Where(x => x.IdStudent == student.Id)
                    .Select(x => x.FirstPartial).
                    Sum() / (student.Course.Subjects.Count),

                    Passed = context.Grades.Where // Evaluacion por estudiante
                    (x => x.IdStudent == student.Id)
                   .All(x => x.FirstPartial >= 6)

                }).Where(x => x.Passed == false)

            }).AsEnumerable();

            return Task.FromResult(Query);
        }

        // GET api/<StudentPassedController>/5
        [HttpGet("{idcourse}")]
        public Task<IEnumerable<StudentCoursePassedDto>> Get(int idcourse)
        {
            var Query = context.Courses.
                Where(x => x.Id == idcourse)
                .Select(course => new StudentCoursePassedDto
                {
                    IdCourse = course.Id,
                    Name = course.Name,

                    Student = course.Students.Select(student => new StudentPassedDto
                    {

                        Name = student.FirstName,
                        PhoneNumber = student.PhoneNumber,
                        Average = context.Grades
                        .Where(x => x.IdStudent == student.Id)
                        .Select(x => x.FirstPartial)
                        .Sum() / (student.Course.Subjects.Count),

                        Passed = context.Grades
                        .Where(x => x.IdStudent == student.Id)
                        .All(x => x.FirstPartial >= 6)

                    }).Where(x => x.Passed == false)
                }).AsEnumerable();

            return Task.FromResult(Query);
        }

    }



}
