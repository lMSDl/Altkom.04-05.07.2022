using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Person : Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        public override string ToString()
        {
            //var line = person.Id + "\t" + person.LastName + " " + person.FirstName + person.Age;
            //var line = string.Format("{0} {2} {1} {3}", person.Id, person.FirstName, person.LastName, person.Age);

            var line = $"{Id,-3}{LastName,-15}{FirstName,-10}{Age,-3}";

            return line;
        }
    }
}
