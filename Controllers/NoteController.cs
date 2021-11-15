using aspDocker.Models;
using aspDocker.ToolModels;
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


        /// <summary>
        /// Get all notes for the specified UserId
        /// </summary>
        /// <param name="applicationUserId"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get([FromQuery] NoteFilterModel query)
        {
            IQueryable<Note> noteQuery = _context.Notes;
            
            // Return for user
            noteQuery = query.UserId != null ? noteQuery.Where(c => c.ApplicationUserId == query.UserId) : noteQuery;

            // Filtering by Title contents
            noteQuery = !String.IsNullOrEmpty(query.NoteTitleContains) ? noteQuery.Where(c => c.NoteTitle.Contains(query.NoteTitleContains)) : noteQuery;

            // Filtering by Body contents
            noteQuery = !String.IsNullOrEmpty(query.NoteTextContains) ? noteQuery.Where(c => c.NoteBody.Contains(query.NoteTextContains)) : noteQuery;

            // Pagination
            if (query.Skip != null && query.Take != null)
            {
                noteQuery = noteQuery.OrderByDescending(c => c.NoteId).Skip(query.Skip.Value - 1 * query.ItemsPerPage.Value).Take(query.Take.Value);
            }

            return noteQuery.ToList().Count > 0 ? Ok(noteQuery.ToList()) : NoContent(); 

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
