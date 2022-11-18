using Maui.Entity.Entity;
using Maui.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Maui.Infrastructure.Configuration.SqlServer
{
    public class MauiContext : DbContext
    {

        public static string? connectionString;
        public MauiContext(DbContextOptions<MauiContext> options) : base(options)
        {
            IConfigurationRoot config = new ConfigurationBuilder().AddUserSecrets<MauiContext>().Build();
            connectionString = config["ConnectionString"];
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Seed();
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            _ = optionsBuilder.UseSqlServer(connectionString);
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<ProjectModel>? Project { get; set; }
    }
}