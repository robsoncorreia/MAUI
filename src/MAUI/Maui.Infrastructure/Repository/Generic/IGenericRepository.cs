namespace Maui.Infrastructure.Repository.Generic
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> Add(T objeto);

        Task Delete(T objeto);

        Task<T> FindById(int id);

        Task<IEnumerable<T>> List(Query.QueryParameters queryParameters);

        Task Update(T objeto);

        Task<IEnumerable<T>> ListExpression(Func<T, bool> expression,
                                            string url,
                                            string token);
    }
}