namespace Maui.Applications.Interface
{
    public interface IGenericApplication<T> where T : class
    {
        Task Add(T @objeto);

        Task Update(T @objeto);

        Task Delete(T @objeto);

        Task<T> FindById(int id);

        Task<IEnumerable<T>> List();
    }
}