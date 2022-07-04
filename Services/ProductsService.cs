using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ProductsService : BaseService<Product>, IService<Product>
    {
        protected override Product CreateInstace()
        {
            return new Product();
        }

        protected override void Edit(Product entity)
        {
            entity.Name = GetData("Nazwa:");

            var success = false;
            float price = 0;
            while (!success)
            {
                var ageString = GetData("Cena:");
                success = float.TryParse(ageString, out price);
            }
            entity.Price = price;
        }
    }
}
