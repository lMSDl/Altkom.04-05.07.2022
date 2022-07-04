using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Delegates
{
    public class BuildInDelegatesExample
    {
        public delegate int OddNumer();
        public event OddNumer OddNumberEvent;

        public OddNumer OddNumberDelegate;


        public bool Substract(int a, int b)
        {
            var result = a - b;
            Console.WriteLine(result);
            return result % 2 != 0;
        }

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


            Method(Add, Substract);
            

            Console.WriteLine($"Counter = {_counter}");
        }

        //public delegate void Method1Delegate(int a, int b);
        //public delegate bool Method2Delegate(int a, int b);
        //private void Method(Method1Delegate method1, Method2Delegate method2)

        //Action - wbudowany delegat dla funkcji nie zwracających rezultatu, gdzie ilość i typ parametrów wejściowych określamy generycznie
        //Func - wbudowany delegat dla funkcji zwracających rezultat
        private void Method(Action<int, int> method1, Func<int, int, bool> method2)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int ii = 0; ii <= i; ii++)
                {
                    method1(i, ii);
                    if (method2(i, ii))
                        OddNumberEvent.Invoke();
                }
            }
        }
    }
}
