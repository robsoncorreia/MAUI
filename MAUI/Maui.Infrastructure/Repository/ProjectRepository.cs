using Maui.Entity.Entity;
using Maui.Infrastructure.Configuration.EF;
using Maui.Infrastructure.Repository.Generic;
using Maui.Infrastructure.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Maui.Infrastructure.Repository
{
    public class ProjectRepository : GenericRepository<ProjectModel>, IProjectRepository
    {
        private readonly DbContextOptions<MauiContext> _dbContextOptions;

        public ProjectRepository()
        {
            _dbContextOptions = new DbContextOptions<MauiContext>();
        }

        public async Task<List<ProjectModel>> ListarUsuarios(Expression<Func<ProjectModel, bool>> expression)
        {
            using MauiContext data = new(_dbContextOptions);
            return await data.Project.Where(expression).AsNoTracking().ToListAsync();
        }
    }
}