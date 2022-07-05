using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Models
{
    public class Product : Entity
    {
        public string Name { get; set; }
        public float Price { get; set; }

        public string NullString {get; set;}
        public int DefaultInt { get; set; }
        public string ReadOnly => $"{Id,-3}{Name,-15}{Price,-5}";
        [JsonIgnore]
        public string IgnoreMe { get; set; } = "IgnoreMeString";

        public override string ToString()
        {
            return $"{Id,-3}{Name,-15}{Price,-5}";
        }
    }
}
