using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class PeopleService : BaseService<Person>, IPeopleService
    {
        private void EditPerson(Person person)
        {
            person.FirstName = GetData(Resources.Properties.Resources.FirstName);
            person.LastName = GetData("Nazwisko:");

            int age = 0;
            //var success = false;
            //while (!success)
            //{
            //    var ageString = GetData("Wiek:");
            //    //metoda zwraca 2 rezultaty. Pierwszy poprzez return, a drugi przez parametr wyjściowy (out)
            //    success = int.TryParse(ageString, out age);
            //}
            GetValidData("Wiek:", x => int.TryParse(x, out age) && age > 18);
            person.Age = age;
        }

        public void MethodForPeople()
        {
            throw new NotImplementedException();
        }

        protected override Person CreateInstace()
        {
            return new Person();
        }

        protected override void Edit(Person entity)
        {
            EditPerson(entity);
        }
    }
}
