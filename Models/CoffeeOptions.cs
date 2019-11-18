using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeShopLab.Models
{
    public class CoffeeOptions
    {
        public static List<CoffeeOptions> coffeeOptions = new List<CoffeeOptions>
        {
            new CoffeeOptions("Caramel Latte", 3.99 ),
            new CoffeeOptions("Cuban Coffee", 1.99),
            new CoffeeOptions("Cafe con Leche", 3.99),
            new CoffeeOptions("Frap", 4.99),
            new CoffeeOptions("Hot Chocolate", 1.99)
        };

        public string Name { get; set; }
        public double Price { get; set; }

        public CoffeeOptions()
        {

        }
        public CoffeeOptions(string name, double price)
        {
            Name = name;
            Price = price;
        }

    }
}
