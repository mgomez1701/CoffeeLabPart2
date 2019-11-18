using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoffeeShopLab.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeShopLab.Controllers
{
    public class NewUserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult RegisterUser()
        {
                return View();
        }

        public IActionResult NewUserSummary(NewUser newUser)
        {
            if (ModelState.IsValid)
            {
                return View(newUser);
            }
            else
            {
                return View("RegisterUser");
            }

        }

    }
}