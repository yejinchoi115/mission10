using System;
using m9.Models;
using Microsoft.AspNetCore.Mvc;

namespace m10.Views.Shared.Components
{
    public class CartSummaryViewComponent : ViewComponent
    {
        private Basket repo;
        public CartSummaryViewComponent(Basket temp)
        {
            repo = temp;
        }
        public IViewComponentResult Invoke()
        {
            //Show cart summaryu
            return View(repo);
        }
    }
}
