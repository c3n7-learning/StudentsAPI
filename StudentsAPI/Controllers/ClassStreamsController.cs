using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentsAPI.Models;

namespace StudentsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassStreamsController : ControllerBase
    {
        private readonly AppDatabaseContext _context;

        public ClassStreamsController(AppDatabaseContext context)
        {
            _context = context;
        }

        // GET: api/ClassStreams
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClassStream>>> GetClassStreams()
        {
            return await _context.ClassStreams.ToListAsync();
        }

        // GET: api/ClassStreams/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ClassStream>> GetClassStream(int id)
        {
            var classStream = await _context.ClassStreams.FindAsync(id);

            if (classStream == null)
            {
                return NotFound();
            }

            return classStream;
        }

        // PUT: api/ClassStreams/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClassStream(int id, ClassStream classStream)
        {
            if (id != classStream.Id)
            {
                return BadRequest();
            }

            _context.Entry(classStream).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClassStreamExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ClassStreams
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ClassStream>> PostClassStream(ClassStream classStream)
        {
            _context.ClassStreams.Add(classStream);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetClassStream", new { id = classStream.Id }, classStream);
        }

        // DELETE: api/ClassStreams/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClassStream(int id)
        {
            var classStream = await _context.ClassStreams.FindAsync(id);
            if (classStream == null)
            {
                return NotFound();
            }

            _context.ClassStreams.Remove(classStream);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ClassStreamExists(int id)
        {
            return _context.ClassStreams.Any(e => e.Id == id);
        }
    }
}
