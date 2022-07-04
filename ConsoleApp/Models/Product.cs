using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Models
{
    public class Product
    {
        //backfield - pole zapasowe dla property
        private string _name;

        //Auto-property
        public float Price { get; set; } = 10;

        //Full-property
        public string Name
        {
            get => _name;
            set
            {
                var upperValue = value.ToUpper(); //value - nazwa parametru settera
                _name = upperValue;
                Modified = DateTime.Now;
            }
        }

        //Read-only property
        //brak możliwości zmiany wartości
        public DateTime Created { get; } //= DateTime.Now; //inicjalizacja wartości podczas tworzenia obiektu
        //property z publicznym dostępem do odczytu, ale ograniczonym dostępen do zapisu
        public DateTime Modified { get; private set; }

        public Product()
        {
            Created = DateTime.Now; // inicjalizacja właściwości read-only
        }

        public void RisePrice(float value)
        {
            Price += value;
        }

        //Property (read-only) + wartość generowana przy dostępie (nie jest składowana/przechowywana)
        public string Info => $"{Name} ({Price})";


        public string PublicField = "I am public!";
    }
}
