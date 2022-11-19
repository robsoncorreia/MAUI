using Maui.Entity.Entity;
using Maui.Infrastructure.Configuration.SqlServer;
using Maui.Infrastructure.Query;
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

        [HttpGet]
        public async Task<ActionResult> GetAllProjects([FromQuery] QueryParameters queryParameters)
        {
            IQueryable<ProjectModel> products = _context.Project;

            products = products
                .Skip((int)(queryParameters.Size * (queryParameters.Page - 1)))
                .Take((int)queryParameters.Size);

            return Ok(await products.ToArrayAsync());
        }

        [HttpGet("Count")]
        public async Task<ActionResult> GetAllProjects()
        {
            IQueryable<ProjectModel> products = _context.Project;

            return Ok(await products.CountAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProjectModel>> GetProjectById(int id)
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
        public async Task<IActionResult> PutProject(int id, ProjectModel projectModel)
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

        // POST: api/Project
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ProjectModel>> PostProject(ProjectModel projectModel)
        {
            _context.Project.Add(projectModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProjectById", new { id = projectModel.Id }, projectModel);
        }

        // DELETE: api/Project/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProject(int id)
        {
            var projectModel = await _context.Project.FindAsync(id);
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