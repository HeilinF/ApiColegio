using ApiColegio.Dtos.StudentDtos;
using ApiColegio.Requests.StudentRequest;
using Application.Dtos.StudentDtos;
using Application.Features.Student.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiColegio.Controllers.StudentController
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : BaseApiController<StudentController>
    {
        public StudentController(ILogger<StudentController> logger, IMediator mediator)
        {
            _loggerInstance= logger;
            _mediatorInstance = mediator;

        }
        private readonly StudentRequest student;

        // GET: api/<StudentController>
        [HttpGet]
        public IQueryable<StudentResponse> Get()
        {
            return student.ToList();

        }

        // GET api/<StudentController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _mediator.Send(new GetStudentByIdQuery() { StudentId = id });
            if (result == null) return BadRequest($"Invalid Id {id}");
            return Ok(result);
        }

        //if (!student.Exist(id)) { return NotFound("No hay un estudiante regristrado con ese Id"); }

        // POST api/<StudentController>
        [HttpPost]
        public ActionResult Post(StudentRegisterDto _student)
        {
            try
            {
                student.Register(_student);
                return Ok(_student);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message + ex.InnerException);
            }
        }

        // PUT api/<StudentController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] StudentUpdateDto _student)
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
