using Maui.Entity.Entity;
using Maui.Infrastructure.Configuration.EF;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Maui.WebApplication.Controllers
{
    [Route("api/Project")]
    [ApiController]
    public class ProjectModelController : ControllerBase
    {
        private readonly MauiContext _context;

        public ProjectModelController(MauiContext context)
        {
            _context = context;
        }

        // GET: api/ProjectModel
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProjectModel>>> GetProject()
        {
            return await _context.Project.ToListAsync();
        }

        // GET: api/ProjectModel/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProjectModel>> GetProjectModel(int id)
        {
            ProjectModel? projectModel = await _context.Project.FindAsync(id);

            return projectModel == null ? (ActionResult<ProjectModel>)NotFound() : (ActionResult<ProjectModel>)projectModel;
        }

        // PUT: api/ProjectModel/5
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
                _ = await _context.SaveChangesAsync();
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

        // POST: api/ProjectModel
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ProjectModel>> PostProjectModel(ProjectModel projectModel)
        {
            _ = _context.Project.Add(projectModel);
            _ = await _context.SaveChangesAsync();

            return CreatedAtAction("GetProjectModel", new { id = projectModel.Id }, projectModel);
        }

        // DELETE: api/ProjectModel/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProjectModel(int id)
        {
            ProjectModel? projectModel = await _context.Project.FindAsync(id);
            if (projectModel == null)
            {
                return NotFound();
            }

            _ = _context.Project.Remove(projectModel);
            _ = await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProjectModelExists(int id)
        {
            return _context.Project.Any(e => e.Id == id);
        }
    }
}