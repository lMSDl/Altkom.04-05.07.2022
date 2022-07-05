using ConsoleApp.Delegates;
using ConsoleApp.LambdaExpression;
using ConsoleApp.Models;
using Newtonsoft.Json;


    Nullable<int> a = null;
    int? b = 5;
    int c;


if(a - b == 0 || a - b == null)
{
    c = (a + b) ?? 0; //?? - jeśli wynik po lewej jest null to użyj wartości po prawej stronie
}
else
{
    var result = a - b;
    //if (result != null)
    //if (result.HasValue)
    //    c = result.Value;
    //else
    //    c = 0;
    c = result.HasValue ? result.Value : 0;
}

// <warunek> ? <true> : <false>
c = (a - b == 0 || a - b == null) ? ((a + b) ?? 0) : ((a - b).HasValue ? (a - b).Value : 0);
c = (((a - b) == 0 || a - b == null) ? (a + b) : (a - b)) ?? 0;


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

static void Delegates()
{
    var test = new BuildInDelegatesExample();

    //Event nie pozwala na wyczyszczenie listy subskrypcji
    //test.OddNumberEvent = SthMethod;
    test.OddNumberDelegate = SthMethod;

    test.Test();


    new LinqExamples().Test();
}