using ApiColegio.Context;
using ApiColegio.Dtos.StudentDtos;
using ApiColegio.Dtos.SubjectDtos;
using ApiColegio.Models;
using ApiColegio.Requests.StudentRequest;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiColegio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {   
       private readonly StudentRequest student;

        public StudentController(StudentRequest student)
        { 
            this.student = student;
        }

        
      
        // GET: api/<StudentController>
        [HttpGet]
        public IQueryable<StudentToListDto> Get()
        {
            return student.ToList();
            
        }

        // GET api/<StudentController>/5
        [HttpGet("{id}")]
        public  ActionResult<IQueryable<StudentToListDto>> Get(int id)
        {
          if (!student.Exist(id)) { return NotFound("No hay un estudiante regristrado con ese Id"); }

          return Ok(student.ToListbyId(id));

        }

        // POST api/<StudentController>
        [HttpPost]
        public ActionResult Post (StudentRegisterDto _student)
        {
            try
            {
                student.Register(_student);
                return Ok(_student);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message + ex.InnerException);
            }
        }

        // PUT api/<StudentController>/5
        [HttpPut("{id}")]
        public ActionResult Put (int id, [FromBody] StudentUpdateDto _student)
        {
            if (id != _student.Id)
            {
                return BadRequest("Los Id no coinciden");
            }
          
            student.Update(_student);
            return Ok(_student);
        }

        // DELETE api/<StudentController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
           student.Delete(id);
        }

    }
}
