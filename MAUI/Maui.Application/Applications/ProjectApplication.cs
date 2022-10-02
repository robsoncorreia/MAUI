using Maui.Applications.Interface;
using Maui.Domain.Interface.Project;
using Maui.Entity.Entity;

namespace Maui.Applications.Applications
{
    public class ProjectApplication : IProjectApplication
    {
        private readonly IProjectService _projectService;

        public ProjectApplication(IProjectService projectService)
        {
            _projectService = projectService;
        }

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

        public async Task<List<ProjectModel>> List()
        {
            return await _projectService.List();
        }

        public async Task Update(ProjectModel project)
        {
            await _projectService.Update(project);
        }
    }
}