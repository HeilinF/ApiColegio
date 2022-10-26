using ApiColegio.Context;
using ApiColegio.Dtos.StudentDtos;
using ApiColegio.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Immutable;
using System.Linq;
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

        [HttpGet]
        public Task<IEnumerable<StudentCoursePassedDto>> Get()
        {
            var Query = context.Courses.Select(course => new StudentCoursePassedDto
            {
                IdCourse = course.IdCourse,
                Name = course.Name,
                
                Student= course.Students.Select(student=> new StudentPassedDto
                {
                      ///Por agregar mas campos de notas
                     ///e implementar un average por materia
                    ///y un average por curso (ya implementado)

                    Name= student.FirstName +" "+student.LastName,
                    PhoneNumber=student.PhoneNumber,
                    Average= context.Grades //Promedio total de los estudiantes
                    .Where(x => x.IdStudent== student.IdStudent)
                    .Select(x => x.FirstPartial).
                    Sum() / (student.Course.Subjects.Count),

                   Passed= context.Grades.Where // Evaluacion por estudiante
                   (x => x.IdStudent == student.IdStudent)
                   .All(x => x.FirstPartial >= 6)

                }).Where(x=>x.Passed==true)

            }).AsEnumerable();

                return Task.FromResult(Query);
        }

        [HttpGet("{idcourse}")]
        public Task<IEnumerable<StudentCoursePassedDto>> Get(int idcourse)
        {
            var Query = context.Courses.
                Where(x=>x.IdCourse==idcourse)
                .Select(course => new StudentCoursePassedDto
                {
                    IdCourse = course.IdCourse,
                    Name = course.Name,

                    Student = course.Students.Select(student => new StudentPassedDto
                    {

                        Name = student.FirstName,
                        PhoneNumber = student.PhoneNumber,
                        Average = context.Grades
                        .Where(x => x.IdStudent == student.IdStudent)
                        .Select(x => x.FirstPartial)
                        .Sum() / (student.Course.Subjects.Count),

                        Passed = context.Grades
                        .Where(x => x.IdStudent == student.IdStudent)
                        .All(x => x.FirstPartial >= 6)

                    }).Where(x => x.Passed == true)
                }).AsEnumerable();

            return Task.FromResult(Query);
        }

        //bool IsPassed(Student student)
        //{
        //    //if (context.Grades.Where
        //    //    (x=>x.IdSubject==context.Students.First().IdStudent)
        //    //    .Any(x => x.FirstPartial < 6))
        //    //{
        //    //    return false;
        //    //}
        //    if(context.Grades.Where(x => x.IdStudent == student.IdStudent).All(x => x.FirstPartial  >=6))
        //    {
        //        return true;
        //    }
        //    else { return false; }
 
        //}
        
        //  double  GetAverage()
        //{
            
        //    double Average = context.Grades
        //    .Where(x => x.IdStudent
        //         == context.Students.First().IdStudent).Select(x => x.FirstPartial).Average();

        //    return Average;
        //}


    }
}
