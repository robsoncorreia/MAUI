using Maui.Entity.Entity;
using Microsoft.EntityFrameworkCore;

namespace Maui.Infrastructure.Configuration.EF
{
    public class MauiContext : DbContext
    {
        public DbSet<Project> Project { get; set; }
    }
}
