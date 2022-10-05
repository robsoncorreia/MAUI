using Maui.Entity.Entity;
using Maui.Infrastructure.Repository.Generic;

namespace Maui.Infrastructure.Repository.Interface
{
    public interface IProjectRepository : IGenericRepository<ProjectModel>
    {
        Task<IEnumerable<ProjectModel>> ListExpression(Func<ProjectModel, bool> expression);
    }
}