using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using m10.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace m10.Controllers
{
    public class ShopperController : Controller
    {
        private IShopperRepository repo { get; set; }
        private Basket basket { get; set; }

        public ShopperController(IShopperRepository temp, Basket b)
        {
            repo = temp;
            basket = b;
        }
        [HttpGet]
        public IActionResult Checkout()
        {
            //show the form and put a Shopper instance into the parameter
            return View(new Shopper());
        }

        [HttpPost]
        public IActionResult Checkout(Shopper shopper)
        {
            // see if basket is empty
            if (basket.Items.Count() == 0)
            {
                // to check see validate/not
                ModelState.AddModelError("", "Sorry, your basket is empty!");
            }

            // if it is valid
            if (ModelState.IsValid)
            {
                // make array of basket items and put it into the shopper.Lines
                shopper.Lines = basket.Items.ToArray();
                //save the shopper
                repo.SaveShopper(shopper);
                //clear current basket after checking out
                basket.ClearBasket();

                return RedirectToPage("/ShoppingCompleted");
            }
            else
            {
                return View();
            }
        }
    }
}
