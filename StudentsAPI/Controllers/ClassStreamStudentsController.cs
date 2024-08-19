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
    public class ClassStreamStudentsController : ControllerBase
    {
        private readonly AppDatabaseContext _context;

        public ClassStreamStudentsController(AppDatabaseContext context)
        {
            _context = context;
        }

        // GET: api/ClassStreamStudents
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Student>>> GetStudents(int id)
        {
            return await _context.Students.Where(student => student.ClassStreamId == id).Include(_ => _.ClassStream).ToListAsync();
        }
    }
}
