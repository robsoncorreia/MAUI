using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Maui.Infrastructure.Configuration.EF
{
    public class ProjectContextFactory : IDesignTimeDbContextFactory<ProjectContext>
    {
        private const string ConnectionString = "Server=(localdb)\\mssqllocaldb;Database=MauiDb;Trusted_Connection=True;MultipleActiveResultSets=true";


        ProjectContext IDesignTimeDbContextFactory<ProjectContext>.CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<ProjectContext> optionsBuilder = new DbContextOptionsBuilder<ProjectContext>();
            DbContextOptionsBuilder<ProjectContext> x = optionsBuilder.UseSqlServer(ConnectionString);
            DbContextOptionsBuilder<ProjectContext> builder = new DbContextOptionsBuilder<ProjectContext>();
            builder.UseSqlServer(ConnectionString);
            return new ProjectContext(builder.Options);
        }
    }
}