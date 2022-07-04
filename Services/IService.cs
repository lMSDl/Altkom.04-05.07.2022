using Models;

namespace Services
{
    //interfejs generyczny
    public interface IService<T>
    {
        IEnumerable<T> Get();
        T Get(int id);
        void Create();
        void Update(int id);
        void Delete(int id);
    }
}
