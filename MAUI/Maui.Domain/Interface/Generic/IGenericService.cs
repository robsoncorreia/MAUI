using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maui.Domain.Interface.Generic
{
    public interface IGenericService<T> where T : class
    {
        Task Add(T @objeto);
        Task Update(T @objeto);
        Task Delete(T @objeto);
        Task<T> FindById(int id);
        Task<List<T>> List();
    }
}
