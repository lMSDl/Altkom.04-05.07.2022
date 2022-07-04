using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    //klasa implementuje interfejs IPeopleService
    public class PeopleService : IPeopleService
    {
        private IList<Person> people;

        public PeopleService()
        {
            people = new List<Person>();
        }


        public void Create()
        {
            var person = new Person();
            EditPerson(person);

            person.Id = GenerateId();

            people.Add(person);
        }


        public void Delete(int id)
        {
            for (int i = 0; i < people.Count; i++)
            {
                var person = people[i];
                if (person.Id == id)
                {
                    people.RemoveAt(i);
                    break;
                }
            }
        }

        public IEnumerable<Person> GetPeople()
        {
            return people;
        }

        public Person GetPerson(int id)
        {
            foreach (var person in people)
            {
                if (person.Id == id)
                    return person;
            }

            return null;
        }

        public void Update(int id)
        {
            var person = GetPerson(id);
            if (person != null)
                EditPerson(person);
        }

        private int GenerateId()
        {
            int id = 0;
            foreach(var person in people)
            {
                id = Math.Max(id, person.Id);
            }

            return id + 1;
        }

        public static string GetData(string label)
        {
            Console.WriteLine(label);
            return Console.ReadLine();
        }
        private void EditPerson(Person person)
        {
            person.FirstName = GetData("Imię:");
            person.LastName = GetData("Nazwisko:");

            var success = false;
            int age = 0;
            while (!success)
            {
                var ageString = GetData("Wiek:");
                //metoda zwraca 2 rezultaty. Pierwszy poprzez return, a drugi przez parametr wyjściowy (out)
                success = int.TryParse(ageString, out age);
            }
            person.Age = age;
        }
    }
}
