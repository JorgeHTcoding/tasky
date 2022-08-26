using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using tasky.Models;
using tasky.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace tasky.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly TaskyDBContext _context;

        public ProjectController(TaskyDBContext context)
        {
            _context = context;
        }
        // GET: api/<ProjectController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProjectModel>>> GetProject()
        {
            if (_context.Project == null)
            {
                return NotFound();
            }
            return await _context.Project.ToArrayAsync();
        }

        // GET api/<ProjectController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProjectModel>> GetProject(int id)
        {
            if (_context == null)
            {
                return NotFound();
            }
            var project = await _context.Project.FindAsync(id);

            if (project == null)
            {
                return NotFound();
            }

            return project;
        }

        // POST api/<ProjectController>
        [HttpPost]
        public async Task<ActionResult<ProjectModel>> PostProject(ProjectModel project)
        {
            if (_context.Project == null)
            {
                return Problem("Entity set 'TaskyDBContext.Project is null'");
            }
            _context.Project.Add(project);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetProject", new { id = project.Id_Project }, project);
        }

        // PUT api/<ProjectController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<ProjectModel>> PutProject(int id, ProjectModel project)
        {
            if (id != project.Id_Project)
            {
                return BadRequest();
            }
            _context.Entry(project).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjectExists(id))
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



        // DELETE api/<ProjectController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ProjectModel>> DeleteProject(int id)
        {
            if (_context.Project == null)
            {
                return NotFound();
            }
            var project = await _context.Project.FindAsync(id);
            if (project == null)
            {
                return NotFound();
            }

            _context.Project.Remove(project);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProjectExists(int id)
        {
            return (_context.Project?.Any(e => e.Id_Project == id)).GetValueOrDefault();
        }
    }
}
