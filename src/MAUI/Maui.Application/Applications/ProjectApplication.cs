using Maui.Applications.Interface;
using Maui.Domain.Interface.Project;
using Maui.Entity.Entity;
using Maui.Infrastructure.Query;

namespace Maui.Applications.Applications
{
    public class ProjectApplication : IProjectApplication
    {
        private readonly IProjectService _projectService;

        public ProjectApplication(IProjectService projectService)
        {
            _projectService = projectService;
        }

        public ProjectModel? SelectedProject { get; set; }

        public async Task Add(ProjectModel project)
        {
            await _projectService.Add(project);
        }

        public async Task Delete(ProjectModel project)
        {
            await _projectService.Delete(project);
        }

        public async Task<ProjectModel> FindById(int id)
        {
            return await _projectService.FindById(id);
        }

        public async Task<IEnumerable<ProjectModel>> List(QueryParameters? queryParameters = null)
        {
            return await _projectService.List(queryParameters);
        }

        public async Task<IEnumerable<ProjectModel>> ListExpression(Func<ProjectModel, bool> expression)
        {
            return await _projectService.ListExpression(expression);
        }

        public async Task Update(ProjectModel project)
        {
            await _projectService.Update(project);
        }

        public async Task<int> Count()
        {
            return await _projectService.Count();
        }
    }
}