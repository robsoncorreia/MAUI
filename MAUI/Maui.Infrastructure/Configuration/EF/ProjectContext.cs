using Maui.Entity.Entity;
using Microsoft.EntityFrameworkCore;

namespace Maui.Infrastructure.Configuration.EF
{
    public class ProjectContext : DbContext
    {
        public ProjectContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<ProjectModel> Project { get; set; }
    }
}
