﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CoffeeShopLab.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace CoffeeShopLab.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            string registeredUserJson = HttpContext.Session.GetString("UserSignedInSession");
            if (registeredUserJson != null)
            {
                NewUser signedInUser = JsonConvert.DeserializeObject<NewUser>(registeredUserJson);
                return View(signedInUser);
            }
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
       

        public IActionResult SignIn(NewUser user)// string username, string password
        {
            // Get the List of the USERS from the SESSION;
            string signInUserJson = HttpContext.Session.GetString("LoginInSession");
            //var sesssJson = HttpContext.Session.GetString("UserListSession");
            //List<NewUser> list = JsonConvert.Deserialize<List<NewUser>(sesssJson);
            if (signInUserJson != null)
            {
                List<NewUser> loginUser = JsonConvert.DeserializeObject<List<NewUser>>(signInUserJson);

                //compare the username AND password FOREACH USER IN the List

                // if(User exists in list)

                foreach (NewUser login in loginUser)
                {
                    if (login.UserName == login.UserName)
                    {
                        if (login.Password == login.Password)
                        {
                            return RedirectToAction("Index", "Home");
                        }
                    }
                }

            }
            return View();
            // Create a new SESSION for the Single USER
            //HttpContext.Session.SetString("UserSignedInSession", JsonConvert.SerializeObject(FOUNDUSER));

           
        }

        public IActionResult ViewProducts()
        {
            var menuList = CoffeeOptions.coffeeOptions.ToList();
            return View(menuList);
        }

    

    }
}
