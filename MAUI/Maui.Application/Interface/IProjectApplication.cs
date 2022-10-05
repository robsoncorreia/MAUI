using Maui.Entity.Entity;
using System.Linq.Expressions;

namespace Maui.Applications.Interface
{
    public interface IProjectApplication : IGenericApplication<ProjectModel>
    {
        Task<IEnumerable<ProjectModel>> ListExpression(Func<ProjectModel, bool> expression);
    }
}