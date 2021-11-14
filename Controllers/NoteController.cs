using aspDocker.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace aspDocker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoteController : ControllerBase
    {
        NoteContext _context;
        public NoteController(NoteContext context)
        {
            _context = context;
        }


        // GET: api/<NoteController>
        [HttpGet]
        public IEnumerable<Note> Get()
        {
            return _context.Notes.ToList();
        }

        // GET api/<NoteController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<NoteController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<NoteController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<NoteController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
