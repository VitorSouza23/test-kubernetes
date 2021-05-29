using System.Threading.Tasks;

namespace backend.Contexts
{
    public interface IRedisContext<T>
    {
        Task InserDataAsync(T value, string key);
    }
}