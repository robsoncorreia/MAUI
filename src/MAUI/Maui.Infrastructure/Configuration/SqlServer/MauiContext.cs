using Maui.Entity.Entity;
using Maui.Infrastructure.Helpers;
using Microsoft.EntityFrameworkCore;

namespace Maui.Infrastructure.Configuration.SqlServer
{
    public class MauiContext : DbContext
    {
        public MauiContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            _ = optionsBuilder.UseSqlServer(UriHelper.GetConfig());
        }

        public DbSet<ProjectModel>? Project { get; set; }
    }
}