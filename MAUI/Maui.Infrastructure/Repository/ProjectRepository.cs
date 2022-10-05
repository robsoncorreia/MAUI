using Maui.Entity.Entity;
using Maui.Infrastructure.Repository.Generic;
using Maui.Infrastructure.Repository.Interface;
using Maui.Infrastructure.Repository.RequestProvider;
using System.Text;
using System.Text.Json;

namespace Maui.Infrastructure.Repository
{
    public class ProjectRepository : GenericRepository<ProjectModel>, IProjectRepository
    {
        private const string MEDIATYPE = "application/json";
        private const string BASEURL = "https://localhost:7058/";
        private const string PROJECTENDPOINT = "api/Project";
        private readonly HttpClient _client;
        private readonly JsonSerializerOptions _serializerOptions;

        public new async Task<IEnumerable<ProjectModel>> List()
        {
            IEnumerable<ProjectModel> projects = await _requestProvider.GetAsync<IEnumerable<ProjectModel>>($"{BASEURL}{PROJECTENDPOINT}", string.Empty).ConfigureAwait(false);

            return projects ?? Enumerable.Empty<ProjectModel>();
        }

        public new async Task Add(ProjectModel project)
        {
            var uri = string.Format($"{BASEURL}{PROJECTENDPOINT}", string.Empty);

            string json = JsonSerializer.Serialize(project);

            StringContent content = new(json, Encoding.UTF8, MEDIATYPE);

            _ = project.Id == 0 ?
                await _requestProvider.PostAsync(uri, content) :
                await _requestProvider.PutAsync(uri, content);
        }

        private readonly IRequestProvider _requestProvider;

        public ProjectRepository(IRequestProvider requestProvider) : base(requestProvider)
        {
            _requestProvider = requestProvider;
            _client = new HttpClient();
            _serializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
        }

        public async Task<IEnumerable<ProjectModel>> ListExpression(Func<ProjectModel, bool> expression)
        {
            IEnumerable<ProjectModel> projects = await _requestProvider.GetAsync<IEnumerable<ProjectModel>>($"{BASEURL}{PROJECTENDPOINT}", string.Empty).ConfigureAwait(false);

            return projects.Where(expression) ?? Enumerable.Empty<ProjectModel>();
        }
    }
}