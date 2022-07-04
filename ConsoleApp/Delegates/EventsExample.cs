using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Delegates
{
    public class EventsExample
    {
        public delegate int OddNumer();
        public event OddNumer OddNumberEvent;

        public OddNumer OddNumberDelegate;


        public void Add(int a, int b)
        {
            var result = a + b;
            Console.WriteLine(result);
            if (result % 2 != 0)
            {
                var eventResult = OddNumberEvent.Invoke();
                Console.WriteLine($"Event result: {eventResult}");
                OddNumberDelegate.Invoke();
            }
        }

        private int _counter = 0;
        int CountOddNumbers()
        {
            return ++_counter;
        
        }

        public void Test()
        {
            OddNumberEvent += CountOddNumbers;
            OddNumberEvent += delegate { Console.WriteLine("Odd number!"); return 0; };


            OddNumberDelegate += CountOddNumbers;

            for (int i = 0; i < 3; i++)
            {
                for (int ii = 0; ii <= i; ii++)
                {
                    Add(i, ii);
                }
            }

            Console.WriteLine($"Counter = {_counter}");
        }
    }
}
