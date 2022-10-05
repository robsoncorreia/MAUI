using Maui.Entity.Entity;

namespace Maui.Applications.Interface
{
    public interface IProjectApplication : IGenericApplication<ProjectModel>
    {
        Task<IEnumerable<ProjectModel>> ListExpression(Func<ProjectModel, bool> expression);
    }
}