using Maui.Entity.Entity;
using Maui.Infrastructure.Repository.Generic;
using System.Linq.Expressions;

namespace Maui.Infrastructure.Repository.Interface
{
    public interface IProjectRepository : IGenericRepository<ProjectModel>
    {
        Task<IEnumerable<ProjectModel>> ListExpression(Func<ProjectModel, bool> expression);
    }
}