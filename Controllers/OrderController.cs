using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoffeeShopLab.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CoffeeShopLab.Controllers
{
    public class OrderController : Controller
    {
        //1.      
        public static List<CoffeeOptions> coffeeOptions = new List<CoffeeOptions>
        {
            new CoffeeOptions("Caramel Latte", 3.99 ),
            new CoffeeOptions("Cuban Coffee", 1.99),
            new CoffeeOptions("Cafe con Leche", 3.99),
            new CoffeeOptions("Frap", 4.99),
            new CoffeeOptions("Hot Chocolate", 1.99)
        };

        public IActionResult Index()
        {
            return View();
        }


        // 2. create a method that check to see if a seession has already been created
        // 3. we will get session and store that in a string
        // 4. if that string is then not empty we will deserialize it and store it in a list <movies>

        private void PopulateList()
        {
            string orderListJson = HttpContext.Session.GetString("SelectedItems");
            if(orderListJson != null)
            {
                coffeeOptions = JsonConvert.DeserializeObject<List<CoffeeOptions>>(orderListJson);
            }
        }
        public IActionResult AddToCart(int id)
        {
            var selectedItem = coffeeOptions[id];
            PopulateList();
            coffeeOptions.Add(selectedItem);

            return View("PlaceOrder", coffeeOptions);
        }


        //public IActionResult AddToCart(OrderController item)
        //{
        //    var selectedItem = coffeeOptions.Find(item);

        //}

    }
}