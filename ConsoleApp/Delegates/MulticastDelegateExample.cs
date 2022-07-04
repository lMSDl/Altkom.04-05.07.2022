using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Delegates
{
    public class MulticastDelegateExample
    {
        public delegate void ShowMessage(string @string);

        public void Message1(string message)
        {
            Console.WriteLine($"1st. msg: {message}");
        }
        public void Message2(string message)
        {
            Console.WriteLine($"2nd. msg: {message}");
        }
        public void Message3(string message)
        {
            Console.WriteLine($"3rd. msg: {message}");
        }

        public void Test()
        {
            ShowMessage showMessage = null;

            showMessage += Message1;
            showMessage += Message2;
            showMessage += Message3;
            showMessage += Message3;

            showMessage("Hi!");

            showMessage -= Message2;
            showMessage -= Message3;
            showMessage("Hello!");

            showMessage = Console.WriteLine;

            showMessage("console");
        }
    }
}
