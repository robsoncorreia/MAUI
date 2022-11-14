using Maui.Entity.Entity;
using Maui.Infrastructure.Configuration.SqlServer;
using Maui.Infrastructure.Repository.Generic;
using Maui.Infrastructure.Repository.Interface;
using Maui.Infrastructure.Repository.RequestProvider;
using Microsoft.Extensions.Configuration;

namespace Maui.Infrastructure.Repository
{
    public class ProjectRepository : GenericRepository<ProjectModel>, IProjectRepository
    {
        private readonly string baseURL;
        private const string PROJECTENDPOINT = "api/Project";
        private readonly IRequestProvider _requestProvider;
        private readonly string uri;

        public override async Task Update(ProjectModel project)
        {
            project.UpdatedAt = DateTime.Now;
            await _requestProvider.PutAsync($"{uri}/{project.Id}", project);
        }

        public override async Task<IEnumerable<ProjectModel>> List()
        {
            IEnumerable<ProjectModel> projects = await _requestProvider.GetAsync<IEnumerable<ProjectModel>>($"{baseURL}{PROJECTENDPOINT}", string.Empty).ConfigureAwait(false);

            return projects ?? Enumerable.Empty<ProjectModel>();
        }

        public override async Task<ProjectModel> Add(ProjectModel project)
        {
            if (project.Id == 0)
            {
                project.CreateAt = DateTime.Now;
                project.UpdatedAt = DateTime.Now;
                return await _requestProvider.PostAsync(uri, project);
            }
            else
            {
                project.UpdatedAt = DateTime.Now;
                return await _requestProvider.PutAsync($"{uri}/{project.Id}", project);
            }
        }

        public ProjectRepository(IRequestProvider requestProvider) : base(requestProvider)
        {
            _requestProvider = requestProvider;
            baseURL = _requestProvider.baseURL;
            uri = string.Format($"{baseURL}{PROJECTENDPOINT}", string.Empty); 
        }

        public async Task<IEnumerable<ProjectModel>> ListExpression(Func<ProjectModel, bool> expression)
        {
            IEnumerable<ProjectModel> projects = await _requestProvider.GetAsync<IEnumerable<ProjectModel>>(uri, string.Empty).ConfigureAwait(false);

            return projects is null ? Enumerable.Empty<ProjectModel>() : projects.Where(expression) ?? Enumerable.Empty<ProjectModel>();
        }
    }
}