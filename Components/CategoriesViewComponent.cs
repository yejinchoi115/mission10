﻿using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using mission10.Models;

namespace mission10.Components
{
    public class TypesViewComponent : ViewComponent
    {
        private IBookstoreRepository repo { get; set; }

        public TypesViewComponent (IBookstoreRepository temp)
        {
            repo = temp;
        }

        public IViewComponentResult Invoke()
        {
            //indicates what the current selected categoryType is
            ViewBag.SelectedType = RouteData?.Values["categoryType"];

            //only show the unique project type
            var types = repo.Books
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x);

            return View(types);
        }
    }
}
