using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Maui.Infrastructure.Configuration.EF
{
    public class ProjectContextFactory : IDesignTimeDbContextFactory<MauiContext>
    {
        MauiContext IDesignTimeDbContextFactory<MauiContext>.CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<MauiContext> optionsBuilder = new();
            return new MauiContext(optionsBuilder.UseSqlServer(UtilConfiguration.CONNECTIONSTRING).Options);
        }
    }
}