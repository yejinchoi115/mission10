using System;
using Microsoft.AspNetCore.Mvc;
using mission10.Models;

namespace mission10.Views.Shared.Components
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
