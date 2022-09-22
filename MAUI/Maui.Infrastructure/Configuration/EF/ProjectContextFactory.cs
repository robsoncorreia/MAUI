using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace Maui.Infrastructure.Configuration.EF
{
    public class ProjectContextFactory : IDesignTimeDbContextFactory<ProjectContext>
    {
        private const string ConnectionString = "Server=(localdb)\\mssqllocaldb;Database=MauiDb;Trusted_Connection=True;MultipleActiveResultSets=true";


        ProjectContext IDesignTimeDbContextFactory<ProjectContext>.CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ProjectContext>();
            var x = optionsBuilder.UseSqlServer(ConnectionString);
            var builder = new DbContextOptionsBuilder<ProjectContext>();
            builder.UseSqlServer(ConnectionString);
            return new ProjectContext(builder.Options);
        }
    }
}