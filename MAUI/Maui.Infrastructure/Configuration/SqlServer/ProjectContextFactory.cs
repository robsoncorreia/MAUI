using Maui.Infrastructure.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Maui.Infrastructure.Configuration.SqlServer
{
    public class ProjectContextFactory : IDesignTimeDbContextFactory<MauiContext>
    {
        MauiContext IDesignTimeDbContextFactory<MauiContext>.CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<MauiContext> optionsBuilder = new();
            return new MauiContext(optionsBuilder.UseSqlServer(UriHelper.GetConfig()).Options);
        }
    }
}