using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Product : Entity
    {
        public string Name { get; set; }
        public float Price { get; set; }

        public override string ToString()
        {
            return $"{Id,-3}{Name,-15}{Price,-5}";
        }
    }
}
