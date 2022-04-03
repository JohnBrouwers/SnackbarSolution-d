using System.Collections.Generic;
using System.Threading.Tasks;

namespace Snackbar.MVC.Services
{
    public interface IApiService<T>
    {
        Task<IEnumerable<T>> GetAsync(string data);
        Task<T> GetAsync(int id, string data);
        Task<bool> AddAsync(T entity, string data);
        Task<bool> UpdateAsync(int id, T entity, string data);
        Task<bool> DeleteAsync(int id, string data);
    }
}
