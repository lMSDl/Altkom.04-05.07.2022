using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Delegates
{
    public class DelegatesExample
    {
        public delegate void NoParametersNoReturn();
        public delegate void NoReturn(string someString);
        public delegate bool ReturnWithParameters(int a, int b);


        public void Func1()
        {
            Console.WriteLine("1");
        }
        public void Func2(string @string)
        {
            Console.WriteLine(@string);
        }
        public bool Func3(int x, int y)
        {
            Console.WriteLine($"x = {x}; y = {y}");
            return x == y;
        }

        public ReturnWithParameters Delegate3 { get; set; }

        public void Test()
        {
            var delegate1 = new NoParametersNoReturn(Func1);

            Func1();
            delegate1();

            NoReturn delegate2 = null;

            if(delegate2 != null)
                delegate2("Hi!");

            delegate2 = Func2;
            if (delegate2 != null)
                delegate2.Invoke("Hello!");

            Delegate3 = Func3;

            for (int i = 0; i < 3; i++)
            {
                for (int ii = 0; ii <= i; ii++)
                {
                    if(Delegate3(i, ii))
                        Console.WriteLine("==");
                }
            }

            Check(Delegate3, 4, 5);
        }


        public bool Check(ReturnWithParameters funtion, int a, int b)
        {
            return funtion(a, b);
        } 
    }
}
