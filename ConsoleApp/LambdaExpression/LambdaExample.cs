using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.LambdaExpression
{
    public class LambdaExample
    {
        Func<int, int, int> Calculator { get; set; }
        Func<string> SomeFunc { get; set; }
        Action<int> SomeAction { get; set; }
        Action AnotherAction { get; set; }

        //wyrażenie lambda
        // <opcjonalne parametry> <operator> <ciało>
        // (a, b) => { };

        public void Test()
        {
            Calculator += //delegate (int a, int b) { return a + b; };
                          //(int a, int b) => { return a + b; };
                          //(a, b) => { return a + b; };
                          (a, b) => a + b;

            SomeFunc += //delegate { return "Hello!"; };
                        () => "Hello!";

            SomeAction += //delegate (int a) { Console.WriteLine(); };
                          //(a) => Console.WriteLine();
                          a => Console.WriteLine();

            AnotherAction += //delegate { Console.WriteLine(); };
                            () => Console.WriteLine();


            SomeMethod(x =>
            {
                var value = x.Replace(",", "|");
                Console.WriteLine(value);
            },
            "A, B, C");

        }

        void SomeMethod(Action<string> stringAction, string someString)
        {
            stringAction(someString);
        }
    }
}
