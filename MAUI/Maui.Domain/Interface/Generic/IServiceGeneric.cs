namespace Maui.Domain.Interface.Generic
{
    public interface IServiceGeneric<T> where T : class
    {
        Task Add(T @objeto);

        Task Update(T @objeto);

        Task Delete(T @objeto);

        Task<T> FindById(int id);

        Task<IEnumerable<T>> List();
    }
}