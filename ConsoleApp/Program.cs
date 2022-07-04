using ConsoleApp.Delegates;
using ConsoleApp.Models;
using Newtonsoft.Json;


var test = new EventsExample();

//Event nie pozwala na wyczyszczenie listy subskrypcji
//test.OddNumberEvent = SthMethod;
test.OddNumberDelegate = SthMethod;

test.Test();


static int SthMethod()
{
    Console.WriteLine(";)");
    return 0;
}



static void Method()
{
    Console.WriteLine("Hello!");


    var product = new Product();

    //product.Price = product.Price + product.Price * 0.1f;
    //product.Price += product.Price * 0.1f;

    product.RisePrice(10);

    Console.WriteLine(product.Modified);

    Console.WriteLine(product.Info);

    Console.WriteLine(JsonConvert.SerializeObject(product));

    Console.ReadLine();

    var pizza = new Pizza { Ham = true, Cheese = true };
    pizza = new Pizza(true, false, true) { Onion = true, PublicField = "a" };

    //Console.WriteLine(  pizza.Ham );
    Console.WriteLine(pizza.PublicField);
}