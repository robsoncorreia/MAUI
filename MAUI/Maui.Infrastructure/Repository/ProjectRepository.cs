using Maui.Entity.Entity;
using Maui.Infrastructure.Configuration.EF;
using Maui.Infrastructure.Repository.Generic;
using Maui.Infrastructure.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Text;
using System.Text.Json;

namespace Maui.Infrastructure.Repository
{
    public class ProjectRepository : GenericRepository<ProjectModel>, IProjectRepository
    {
        private const string MediaType = "application/json";
        private const string BASEURL = "https://localhost:7058/";
        private const string PROJECTENDPOINT = "api/Project";
        private readonly HttpClient _client;
        private readonly JsonSerializerOptions _serializerOptions;

        public new async Task Add(ProjectModel project)
        {
            Uri uri = new(string.Format($"{BASEURL}{PROJECTENDPOINT}", string.Empty));

            string json = JsonSerializer.Serialize(project);

            StringContent content = new(json, Encoding.UTF8, MediaType);

            if (project.Id == 0)
            {
                _ = await _client.PostAsync(uri, content);
            }
            else
            {
                _ = await _client.PutAsync(uri, content);
            }
        }

        private readonly DbContextOptions<MauiContext> _dbContextOptions;

        public ProjectRepository()
        {
            _dbContextOptions = new DbContextOptions<MauiContext>();
            _client = new HttpClient();
            _serializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
        }

        public async Task<List<ProjectModel>> ListarUsuarios(Expression<Func<ProjectModel, bool>> expression)
        {
            using MauiContext data = new(_dbContextOptions);
            return await data.Project.Where(expression).AsNoTracking().ToListAsync();
        }
    }
}