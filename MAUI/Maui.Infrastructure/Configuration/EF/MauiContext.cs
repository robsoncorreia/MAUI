using Maui.Entity.Entity;
using Microsoft.EntityFrameworkCore;

namespace Maui.Infrastructure.Configuration.EF
{
    public class MauiContext : DbContext
    {
        public MauiContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(UtilConfiguration.CONNECTIONSTRING);
        }

        public DbSet<ProjectModel>? Project { get; set; }
    }
}