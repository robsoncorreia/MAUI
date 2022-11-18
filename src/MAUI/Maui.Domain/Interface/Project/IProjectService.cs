using Maui.Domain.Interface.Generic;
using Maui.Entity.Entity;

namespace Maui.Domain.Interface.Project
{
    public interface IProjectService : IServiceGeneric<ProjectModel>
    {
        Task<int> Count();
        Task<IEnumerable<ProjectModel>> ListExpression(Func<ProjectModel, bool> expression);
    }
}