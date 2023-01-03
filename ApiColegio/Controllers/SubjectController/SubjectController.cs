using ApiColegio.Dtos.SubjectDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiColegio.Requests.SubjectRequest;
using Domain.Context;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiColegio.Controllers.Subject
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        private readonly SubjectRequest subject;
        private readonly ConexionSQLServer context;

        public SubjectController(ConexionSQLServer context, SubjectRequest subject)
        {
            this.subject = subject;
            this.context = context;
        }
        // GET: api/<SubjectController>
        [HttpGet]
        public IQueryable<SubjectToListDto> Get()
        {
            return subject.ToList();
        }

        // GET api/<SubjectController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            if (!subject.Exist(id))
            {
                return NotFound("NO se encontro esa materia");
            }
            else
            {
                return Ok(subject.ToListById(id));
            }
        }

        // POST api/<SubjectController>
        [HttpPost]
        public ActionResult Post([FromBody] SubjectRegisterDto _subject)
        {
            try
            {
                subject.Create(_subject);
                return Ok(_subject);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return BadRequest(ex.Message + ex.InnerException);
            }
        }

        // PUT api/<SubjectController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] SubjectUpdateDto _subject)
        {
            if (_subject.Id != id)
                return NotFound("Los Id No Coinciden");
            try
            {
                subject.Update(_subject);
                return Ok(_subject);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return BadRequest(ex.Message + ex.InnerException);
            }
        }

        // DELETE api/<SubjectController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            subject.Delete(id);
        }


    }
}
