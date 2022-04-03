using System.Collections.Generic;
using System.Threading.Tasks;

namespace Snackbar.MVC.Services
{
    public interface IApiService<T>
    {
        Task<IEnumerable<T>> GetAsync(string controller);
        Task<T> GetAsync(int id, string controller);
        Task<bool> AddAsync(T entity, string controller);
        Task<bool> UpdateAsync(int id, T entity, string controller);
        Task<bool> DeleteAsync(int id, string controller);
    }
}
