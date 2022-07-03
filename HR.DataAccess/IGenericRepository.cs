using HR.Api.DataAccess;
using HR.Api.DataAccess.Entities;

namespace HR.DataAccess
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();

        Task<T> Create(T t);

        Task<T> Get(int id);
        Task<T> Update(int id, T t);
        Task<bool> Delete(int id);
    }
}