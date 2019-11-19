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
    public class NewUserController : Controller
    {
        List<NewUser> savedUser = new List<NewUser>();
        public IActionResult Index()
        {
          return View();          
        }

        public IActionResult SaveUser(NewUser newUser)
        {
            if (ModelState.IsValid)
            {
                PopulateFromSession();
                savedUser.Add(newUser);
                HttpContext.Session.SetString("UserListSession",
                JsonConvert.SerializeObject(savedUser));

                HttpContext.Session.SetString("UserSignedInSession", JsonConvert.SerializeObject(newUser));

                return RedirectToAction("NewUserSummary", newUser);
            }
            else
            {
                return RedirectToAction("RegisterUser", newUser);
            }


        }


        public IActionResult RegisterUser(NewUser user)
        {
            
             return View(user);
                   
        }
     
        public void PopulateFromSession()
        {
            string userListJson = HttpContext.Session.GetString("UserListSession");
            if(userListJson != null)
            {
                savedUser = JsonConvert.DeserializeObject<List<NewUser>>(userListJson);
            }
        }

        public IActionResult NewUserSummary(NewUser newUser)
        {
            if (ModelState.IsValid)
            {
                return View(newUser);
            }
            else
            {
                return View();
            }

        }

    }
}