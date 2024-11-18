using System;
using System.Collections.Generic;
using System.Linq;
using WebApplication1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApplication1.Controllers
{
    public class TasksController : Controller
    {
        public IActionResult Index()
        {
            return RedirectToAction("SprintTasks");
        }

        public IActionResult SprintTasks()
        {
            return View();
        }

        public IActionResult Greetings()
        {
            DateTime dateTime = DateTime.Now;

            ViewData["CurrentDate"] = dateTime;
            ViewData["MyMessage"] = "hi, c#";
            ViewData["Greeting"] = "Welcome to my project";
            ViewData["Wish"] = "Be happy)";


            return View();
        }

        public IActionResult ProductInfo()
        {
            List<Product> products = new List<Product>
            {
                new Product("Bread", 10),
                new Product("Milk", 11),
                new Product("Cheese", 140),
                new Product("Sausage", 110),
                new Product("Potato", 7),
                new Product("Banana", 23),
                new Product("Tomato", 25),
                new Product("Candy", 75)
            };

            


            ViewData["products"] = products;

            return View();
        }


        public IActionResult SuperMarkets()
        {
            List<string> markets = new List<string>
            {
                "WellMart",
                "Silpo",
                "АТБ",
                "Furshet",
                "Metro"
            };

            ViewBag.Markets = markets;

            return View();
        }

        public IActionResult ShoppingList()
        {
            Dictionary<string, int> shoppingList = new Dictionary<string, int>
            {
                { "Milk", 2 },
                { "Bread", 2 },
                { "Cake", 1 },
                { "Ice Cream", 5 },
                { "Cola", 10 }
            };

            return View(shoppingList);
        }

        public IActionResult ShoppingCart(string fullname, string address, string selectedSupermarket, string shippingDate, string[] shoppingList)
        {
            List<Product> products = new List<Product>
            {
                new Product("Bread", 10),
                new Product("Milk", 11),
                new Product("Cheese", 140),
                new Product("Sausage", 110),
                new Product("Potato", 7),
                new Product("Banana", 23),
                new Product("Tomato", 25),
                new Product("Candy", 75)
            };

            List<string> superMarkets = new List<string>
            {
                "WellMart",
                "Silpo",
                "АТБ",
                "Furshet",
                "Metro"
            };

            ViewBag.SuperMarkets = superMarkets.Select(sm => new SelectListItem
            {
                Value = sm,
                Text = sm
            }).ToList();

            var today = DateTime.Today;
            ViewBag.ShippingDates = new List<SelectListItem>
            {
                new SelectListItem { Value = today.ToShortDateString(), Text = today.ToShortDateString() },
                new SelectListItem { Value = today.AddDays(1).ToShortDateString(), Text = today.AddDays(1).ToShortDateString() },
                new SelectListItem { Value = today.AddDays(2).ToShortDateString(), Text = today.AddDays(2).ToShortDateString() }
            };

            ViewBag.Products = products.Select(p => new SelectListItem
            {
                Value = p.Name,
                Text = p.Name
            }).ToList();

            if (ModelState.IsValid)
            {
                ViewBag.Message = $"Your products will be shipped at: {address}. Bon appetite, {fullname}.";
            }
            

            return View();
        }


    }
}
