using System.Collections.Generic;
using System.Threading.Tasks;

namespace backend.Contexts
{
    public interface IRedisContext<T>
    {
        Task InserData(T value, string key);
        Task<T> GetData(string key);
        Task<IEnumerable<T>> GetAll();
    }
}