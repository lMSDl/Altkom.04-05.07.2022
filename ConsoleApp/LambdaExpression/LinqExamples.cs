using ConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.LambdaExpression
{
    public class LinqExamples
    {
        int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

        IEnumerable<string> strings = "wlazł kotek na płotek".Split(' ');

        ICollection<Product> products = new List<Product> { new Product { Name = "Jabłka", Price = 12.2f},
                                                            new Product { Name = "Nektarynki", Price = 77.31f},
                                                            new Product { Name = "Gruszki", Price = 122.1f},
                                                            new Product { Name = "Cytryny", Price = 8.23f},
                                                            new Product { Name = "Arbuzy", Price = 1.7f},
                                                            new Product { Name = "Banany", Price = 9.13f},
                                                            new Product { Name = "Śliwki", Price = 44.2f},
                                                            new Product { Name = "Pomarańcze", Price = 1.2f}};


        public void Test()
        {
            var queryResult = from item in numbers where item % 2 == 0 select item;

            var queryResult1 = numbers.Where(item => item % 2 == 0)/*.Select(x => x)*/.ToList();
            var queryResult3 = numbers.Where(item => item % 2 == 0)
                                      .Where(x => x % 3 == 0)
                                      .ToList();
            var queryResult4 = numbers.Where(item => item % 2 == 0 || item % 3 == 0)
                                      .ToList();

            var queryResult5 = strings.Where(x => x.Length >= 4).OrderByDescending(x => x.Length).ThenBy(x => x).ToList();

            var queryResult6 = products.Any(x => x.Name == "Ogórek");

            var queryResult7 = products.Where(x => x.Price > 50).First();
            var queryResult8 = products.Where(x => x.Price > 500).FirstOrDefault();
            var queryResult9 = products.Where(x => x.Price > 100).Single();
            var queryResult10 = products.Where(x => x.Price > 500).SingleOrDefault();


            var queryResult11 = products.Select(x => x.Price).Where(x => x < 100).Max();


            //1. Wybrać parzyste liczby, które są większe od 6 lub mniejsze od 4. Ustawić je malejąco.
            var queryResult12 = numbers.Where(x => x % 2 == 0).Where(x => x > 6 || x < 4).OrderByDescending(x => x).ToList();
            //2. Wybrać listę długości wyrazów i ustawić je w kolejności alfabetycznej (tych wyrazów)
            var queryResult13 = strings.OrderBy(x => x).Select(x => x.Length).ToList();
            //3. Podać średnią cenę produktów
            //var queryResult14 = products.Select(x => x.Price).Average();
            var queryResult14 = products.Average(x => x.Price);
            //4. Jakie produkty kupimy za 2 zł?
            var querResult15 = products.Where(x => x.Price <= 2).ToList();
            //5. Jeden produkt, który kończy się na "y"
            var querResult16 = products.Where(x => x.Name.EndsWith("y", true, CultureInfo.InvariantCulture)).FirstOrDefault();
            //6. Wybrać listę stringów po przekształceniu produktów w ciąg znaków: "<nazwa>: <cena>zł"
            var querResult17 = products.Select(x => $"{x.Name}: {x.Price}zł").ToList();

        }

    }
}
