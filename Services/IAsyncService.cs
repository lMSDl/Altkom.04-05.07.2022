using Models;

namespace Services
{
    //interfejs generyczny
    public interface IAsyncService<T>
    {
        Task<IEnumerable<T>> GetAsync();
        Task<T> GetAsync(int id);
        Task CreateAsync();
        Task UpdateAsync(int id);
        Task DeleteAsync(int id);
    }
}
