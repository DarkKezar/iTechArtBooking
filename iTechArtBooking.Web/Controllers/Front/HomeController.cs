﻿using Microsoft.AspNetCore.Mvc;

namespace iTechArtBooking.Web.Controllers.Front
{
    [Route("")]
    [Controller]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View("home");
        }
    }
}
