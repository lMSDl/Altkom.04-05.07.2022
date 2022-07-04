using ConsoleApp.Models;
using System;
using System.Collections.Generic;
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
        }

    }
}
