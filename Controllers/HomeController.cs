﻿using Microsoft.AspNetCore.Mvc;

namespace CrudOperationsDotNet8.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
