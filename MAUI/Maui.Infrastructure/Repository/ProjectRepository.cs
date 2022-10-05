using Maui.Entity.Entity;
using Maui.Infrastructure.Repository.Generic;
using Maui.Infrastructure.Repository.Interface;
using Maui.Infrastructure.Repository.RequestProvider;

namespace Maui.Infrastructure.Repository
{
    public class ProjectRepository : GenericRepository<ProjectModel>, IProjectRepository
    {
        private const string BASEURL = "https://localhost:7058/";
        private const string PROJECTENDPOINT = "api/Project";
        private readonly IRequestProvider _requestProvider;

        public override async Task<IEnumerable<ProjectModel>> List()
        {
            IEnumerable<ProjectModel> projects = await _requestProvider.GetAsync<IEnumerable<ProjectModel>>($"{BASEURL}{PROJECTENDPOINT}", string.Empty).ConfigureAwait(false);

            return projects ?? Enumerable.Empty<ProjectModel>();
        }

        public override async Task<ProjectModel> Add(ProjectModel project)
        {
            string uri = string.Format($"{BASEURL}{PROJECTENDPOINT}", string.Empty);

            return project.Id == 0 ?
                await _requestProvider.PostAsync(uri, project) :
                await _requestProvider.PutAsync(uri, project);
        }

        public ProjectRepository(IRequestProvider requestProvider) : base(requestProvider)
        {
            _requestProvider = requestProvider;
        }

        public async Task<IEnumerable<ProjectModel>> ListExpression(Func<ProjectModel, bool> expression)
        {
            IEnumerable<ProjectModel> projects = await _requestProvider.GetAsync<IEnumerable<ProjectModel>>($"{BASEURL}{PROJECTENDPOINT}", string.Empty).ConfigureAwait(false);

            return projects.Where(expression) ?? Enumerable.Empty<ProjectModel>();
        }
    }
}