using ConsoleApp.Models;
using Newtonsoft.Json;

Console.WriteLine("Hello!");


var product = new Product();

//product.Price = product.Price + product.Price * 0.1f;
//product.Price += product.Price * 0.1f;

product.RisePrice(10);

Console.WriteLine(product.Modified);

Console.WriteLine(product.Info);

Console.WriteLine(JsonConvert.SerializeObject(product));