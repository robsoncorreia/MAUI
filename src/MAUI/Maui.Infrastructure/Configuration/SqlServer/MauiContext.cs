using Maui.Entity.Entity;
using Maui.Infrastructure.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Maui.Infrastructure.Configuration.SqlServer
{
    public class MauiContext : DbContext
    {

        public static string? connectionString;
        public MauiContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder().AddUserSecrets<MauiContext>().Build();
            connectionString = config["Maui:ConnectionString"];
            _ = optionsBuilder.UseSqlServer(connectionString);
        }

        public DbSet<ProjectModel>? Project { get; set; }
    }
}