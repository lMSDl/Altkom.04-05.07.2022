using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Models
{

    //Klasa o potencjalnie rozbudowanych konstruktorach teleskopowych
    //Właściwości mogą posłużyć do pozbycia się konstruktorów, przez zastąpienie ich inicjalizatorem
    //możemy korzystać jednocześnie z konstruktora i inicjalizatora
    public class Pizza : Product
    {
        public Pizza()
        {

        }

        public Pizza(bool cheese, bool sauce, bool ham, bool onion, bool tomato) : this(cheese, ham, sauce)
        {
            Onion = onion;
            Tomato = tomato;
        }
        public Pizza(bool cheese,  bool ham, bool sauce)
        {
            Cheese = cheese;
            Sauce = sauce;
            Ham = ham;
        }
        //public Pizza(bool cheese, bool sauce, bool tomato)
        //{
        //    Cheese = cheese;
        //    Sauce = sauce;
        //    Tomato = tomato;
        //}


        public bool Cheese { get; set; }
        public bool Sauce {get; set;}
        public bool Ham { private get; set; }
        public bool Onion { get; set; }
        public bool Tomato { get; set; }
    }
}
