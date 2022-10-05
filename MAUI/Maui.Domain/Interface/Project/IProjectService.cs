using Maui.Domain.Interface.Generic;
using Maui.Entity.Entity;
using System.Linq.Expressions;

namespace Maui.Domain.Interface.Project
{
    public interface IProjectService : IServiceGeneric<ProjectModel>
    {
        Task<IEnumerable<ProjectModel>> ListExpression(Func<ProjectModel, bool> expression);
    }
}