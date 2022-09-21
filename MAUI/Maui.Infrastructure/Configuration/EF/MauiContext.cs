using Maui.Entity.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maui.Infrastructure.Configuration.EF
{
    public class MauiContext : DbContext
    { 
        public DbSet<Project> Project { get; set; }
    }
}
