using Models;

namespace Services
{
    //interfejs bazowy określa metody dla typu generycznego,
    //a w interfejsach dziedziczących możemy zamieścić metody specyficzne dla konkretnego typu
    public interface IPeopleService : IService<Person>
    {
        void MethodForPeople();
    }
}
