using Maui.Infrastructure.Configuration.EF;
using Maui.Infrastructure.Repository.RequestProvider;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Maui.Infrastructure.Repository.Generic
{
    public class GenericRepository<T> : IDisposable, IGenericRepository<T> where T : class
    {
        private readonly DbContextOptions<MauiContext> _dbContextOptions;
        private readonly IRequestProvider _requestProvider;

        public GenericRepository(IRequestProvider requestProvider)
        {
            _requestProvider = requestProvider;
            _dbContextOptions = new DbContextOptions<MauiContext>();
        }

        public GenericRepository(IRequestProvider request, IRequestProvider requestProvider) : this(request)
        {
            RequestProvider = requestProvider;
        }

        public IRequestProvider RequestProvider { get; }

        public async Task Add(T objeto)
        {
            using MauiContext data = new(_dbContextOptions);
            _ = await data.Set<T>().AddAsync(objeto);
            _ = await data.SaveChangesAsync();
        }

        public async Task Delete(T objeto)
        {
            using MauiContext data = new(_dbContextOptions);
            _ = data.Set<T>().Remove(objeto);
            _ = await data.SaveChangesAsync();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public async Task<T> FindById(int id)
        {
            using MauiContext data = new(_dbContextOptions);
            return await data.Set<T>().FindAsync(id);
        }

        public async Task<IEnumerable<T>> List()
        {
            using MauiContext data = new(_dbContextOptions);
            return await data.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task Update(T objeto)
        {
            using MauiContext data = new(_dbContextOptions);
            _ = data.Set<T>().Update(objeto);
            _ = await data.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> ListExpression(Func<T, bool> expression,
                                                                string url,
                                                                string token)
        {
            var projects = await _requestProvider.GetAsync<IEnumerable<T>>(url, token).ConfigureAwait(false);

            return projects.Where(expression) ?? Enumerable.Empty<T>();
        }
    }
}