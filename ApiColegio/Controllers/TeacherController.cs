using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiColegio.Dtos.TeacherDtos;
using ApiColegio.Context;
using ApiColegio.Requests.TeacherRequest;

// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
namespace ApiColegio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly TeacherRequest teacher;
        public TeacherController(TeacherRequest teacher)
        {
           
            this.teacher = teacher;
        }

        // GET: api/Teacher
        [HttpGet]
        public  IQueryable<TeacherToListDto> Get()
        {
           return  teacher.ToList();
        }

        // GET: api/Teacher/5
        [HttpGet("{id}")]
        public  ActionResult Get(int id)
        {
            if (!teacher.Exists(id)) 
            { 
                return NotFound("No hay un Profesor registrado con ese Id"); 
            }
            else 
            { 
                return Ok(teacher.ToListById(id)); 
            }

        }

        // PUT: api/Teacher/5
 
        [HttpPut("{id}")]
        public ActionResult Put(int id, TeacherUpdateDto _teacher)
        {
            if (id==_teacher.Id) 
            {
                return NotFound("Los Id no coinciden"); 
            }
            try
            {
                teacher.Update(_teacher);
                return Ok(_teacher);
            }
            catch(DbUpdateConcurrencyException ex)
            {
                return BadRequest(ex.Message + ex.InnerException);
            }
            
        }

        // POST: api/Teacher
        [HttpPost]
        public  ActionResult Post(TeacherRegisterDto _teacher)
        {
            try
            {
                teacher.Register(_teacher);
                return Ok(_teacher);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message + ex.InnerException);
            }
        }

        // DELETE: api/Teacher/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            teacher.Remove(id);
        }


    }
}


