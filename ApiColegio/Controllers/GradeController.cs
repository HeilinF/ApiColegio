using ApiColegio.Context;
using ApiColegio.Dtos.GradeDtos;
using ApiColegio.Dtos.SubjectDtos;
using ApiColegio.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiColegio.Controllers
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
        public Task<IEnumerable<GradeToListDto>> Get()
        {
            var query = context.Grades.Select(grade => new GradeToListDto
            {
                Student= grade.Student,
                Record=grade.Subject.Grades.Select(grade=> new SubjectGradeToList
                {
                  //  Student= grade.Student.FirstName,

                    Subject= grade.Subject.Name,
                    Qualification= grade.Qualification

                })
                
            }).AsEnumerable();

            return Task.FromResult(query);
            
        }

        // GET api/<GradeController>/5
        [HttpGet("{id}")]
        public Task<IEnumerable<GradeToListDto>> Get(int id)
        {
            var query = context.Grades.Select(grade => new GradeToListDto
            {
                Student = grade.Student,
                Record = grade.Subject.Grades.Select(grade => new SubjectGradeToList
                {
                    //  Student= grade.Student.FirstName,

                    Subject = grade.Subject.Name,
                    Qualification = grade.Qualification

                })

            }).Where(x=>x.Student.IdStudent==id).AsEnumerable();

            return Task.FromResult(query);

        }

        // POST api/<GradeController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<GradeController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<GradeController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
