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

        public async Task Add(Project project)
        {
           await _iprojectService.Add(project);
        }

        public async Task Delete(Project project)
        {
            await _iprojectService.Delete(project);
        }

        public async Task<Project> FindById(int id)
        {
            return await _iprojectService.FindById(id);
        }

        public async Task<List<Project>> List()
        {
            return await _iprojectService.List();
        }

        public async Task Update(Project project)
        {
            await _iprojectService.Update(project);
        }
    }
}
