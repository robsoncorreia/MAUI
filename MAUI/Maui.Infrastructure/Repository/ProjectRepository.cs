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
        private readonly HttpClient _client;
        private readonly JsonSerializerOptions _serializerOptions;

        public async Task Add(ProjectModel project)
        {
            Uri uri = new Uri(string.Format("https://localhost:7058/api/Project", string.Empty));

            try
            {
                string json = JsonSerializer.Serialize<ProjectModel>(project);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = null;

                if (true/*isNewItem*/)
                {
                    response = await _client.PostAsync(uri, content);
                }
                else
                {
                    response = await _client.PutAsync(uri, content);
                }

                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine(@"\tTodoItem successfully saved.");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
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