﻿using Microsoft.AspNetCore.Mvc;

namespace Repositorypattern.UI.Controllers
{
    public class StatesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
