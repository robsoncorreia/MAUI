namespace Maui.Infrastructure.Repository.Generic
{
    public interface IGenericRepository<T> where T : class
    {
        Task Add(T objeto);

        Task Delete(T objeto);

        Task<T> FindById(int id);

        Task<IEnumerable<T>> List();

        Task Update(T objeto);

        Task<IEnumerable<T>> ListExpression(Func<T, bool> expression,
                                            string url,
                                            string token);
    }
}