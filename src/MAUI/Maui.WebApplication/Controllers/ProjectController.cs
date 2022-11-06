using Maui.Entity.Entity;
using Maui.Infrastructure.Configuration.SqlServer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Maui.WebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly MauiContext _context;

        public ProjectController(MauiContext context)
        {
            _context = context;
        }

        // GET: api/Project
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProjectModel>>> GetProject()
        {
            return await _context.Project.ToListAsync();
        }

        // GET: api/Project/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProjectModel>> GetProjectModel(int id)
        {
            var projectModel = await _context.Project.FindAsync(id);

            if (projectModel == null)
            {
                return NotFound();
            }

            return projectModel;
        }

        // PUT: api/Project/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProjectModel(int id, ProjectModel projectModel)
        {
            if (id != projectModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(projectModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjectModelExists(id))
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

        // POST: api/Project
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ProjectModel>> PostProjectModel(ProjectModel projectModel)
        {
            _context.Project.Add(projectModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProjectModel", new { id = projectModel.Id }, projectModel);
        }

        // DELETE: api/Project/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProjectModel(int id)
        {
            var projectModel = await _context.Project.FindAsync(id);
            if (projectModel == null)
            {
                return NotFound();
            }

            _context.Project.Remove(projectModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProjectModelExists(int id)
        {
            return _context.Project.Any(e => e.Id == id);
        }
    }
}