using Maui.Domain.Interface.Project;
using Maui.Entity.Entity;
using Maui.Infrastructure.Query;
using Maui.Infrastructure.Repository.Interface;

namespace Maui.Domain.Service
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;

        public ProjectService(IProjectRepository projectService)
        {
            _projectRepository = projectService;
        }

        public async Task Add(ProjectModel project)
        {
            await _projectRepository.Add(project);
        }

        public async Task Delete(ProjectModel project)
        {
            await _projectRepository.Delete(project);
        }

        public async Task<ProjectModel> FindById(int id)
        {
            return await _projectRepository.FindById(id);
        }

        public async Task<IEnumerable<ProjectModel>> List(QueryParameters queryParameters = null)
        {
            return await _projectRepository.List(queryParameters);
        }

        public async Task<IEnumerable<ProjectModel>> ListExpression(Func<ProjectModel, bool> expression)
        {
            return await _projectRepository.ListExpression(expression);
        }

        public async Task Update(ProjectModel project)
        {
            await _projectRepository.Update(project);
        }

        public async Task<int> Count()
        {
           return await _projectRepository.Count();
        }
    }
}