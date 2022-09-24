using Maui.Domain.Interface.Project;
using Maui.Entity.Entity;

namespace Maui.Domain.Service
{
    public class ProjectService : IProjectService
    {

        private readonly IProjectService _iprojectService;

        public ProjectService(IProjectService iprojectService)
        {
            _iprojectService = iprojectService;
        }

        public async Task Add(ProjectModel project)
        {
           await _iprojectService.Add(project);
        }

        public async Task Delete(ProjectModel project)
        {
            await _iprojectService.Delete(project);
        }

        public async Task<ProjectModel> FindById(int id)
        {
            return await _iprojectService.FindById(id);
        }

        public async Task<List<ProjectModel>> List()
        {
            return await _iprojectService.List();
        }

        public async Task Update(ProjectModel project)
        {
            await _iprojectService.Update(project);
        }
    }
}
