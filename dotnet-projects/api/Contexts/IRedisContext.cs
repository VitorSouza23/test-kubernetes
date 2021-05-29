using System.Collections.Generic;
using System.Threading.Tasks;

namespace api.Contexts
{
    public interface IRedisContext<T>
    {
        Task<T> GetDataAsync(string key);
        Task<IEnumerable<T>> GetAllAsync();
    }
}