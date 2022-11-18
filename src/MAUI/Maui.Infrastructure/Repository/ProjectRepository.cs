using Maui.Entity.Entity;
using Maui.Infrastructure.Query;
using Maui.Infrastructure.Repository.Generic;
using Maui.Infrastructure.Repository.Interface;
using Maui.Infrastructure.Repository.RequestProvider;

namespace Maui.Infrastructure.Repository
{
    public class ProjectRepository : IGenericRepository<ProjectModel>, IProjectRepository, IDisposable
    {
        private readonly string baseURL;
        private const string PROJECTENDPOINT = "api/Project";
        private readonly IRequestProvider _requestProvider;
        private readonly string uri;

        public async Task Update(ProjectModel project)
        {
            project.UpdatedAt = DateTime.Now;
            _ = await _requestProvider.PutAsync($"{uri}/{project.Id}", project);
        }

        public async Task<IEnumerable<ProjectModel>> List(QueryParameters queryParameters  = null)
        {
            IEnumerable<ProjectModel> projects = await _requestProvider.GetAsync<IEnumerable<ProjectModel>>($"{baseURL}{PROJECTENDPOINT}", string.Empty, queryParameters).ConfigureAwait(false);

            return projects ?? Enumerable.Empty<ProjectModel>();
        }


        public async Task<int> Count()
        {
           return await _requestProvider.GetAsync<int>($"{baseURL}{PROJECTENDPOINT}/Count", string.Empty).ConfigureAwait(false);
        }

        public async Task<ProjectModel> Add(ProjectModel project)
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

        public ProjectRepository(IRequestProvider requestProvider)
        {
            _requestProvider = requestProvider;
            baseURL = _requestProvider.baseURL ?? "https://localhost:7058/";
            uri = string.Format($"{baseURL}{PROJECTENDPOINT}", string.Empty);
        }

        public async Task<IEnumerable<ProjectModel>> ListExpression(Func<ProjectModel, bool> expression)
        {
            IEnumerable<ProjectModel> projects = await _requestProvider.GetAsync<IEnumerable<ProjectModel>>(uri, string.Empty).ConfigureAwait(false);

            return projects is null ? Enumerable.Empty<ProjectModel>() : projects.Where(expression) ?? Enumerable.Empty<ProjectModel>();
        }


        public async Task Delete(ProjectModel project)
        {
             await _requestProvider.DeleteAsync($"{uri}/{project.Id}");
        }

        public Task<ProjectModel> FindById(int id)
        {
            return _requestProvider.GetAsync < ProjectModel>($"{uri}/{id}");
        }

        public Task<IEnumerable<ProjectModel>> ListExpression(Func<ProjectModel, bool> expression, string url, string token)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
        }
    }
}