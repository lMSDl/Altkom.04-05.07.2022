using Models;

namespace Services
{
    public interface IPeopleService
    {
        //brak kodyfikatora dostępu = public
        IEnumerable<Person> GetPeople();
        Person GetPerson(int id);
        void Create();
        void Update(int id);
        void Delete(int id);
    }
}
