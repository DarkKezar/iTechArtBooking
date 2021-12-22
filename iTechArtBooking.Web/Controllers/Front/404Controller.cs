using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iTechArtBooking.Web.Controllers.Front
{
    [Route("404")]
    [Controller]
    public class _404Controller : Controller
    {
        public IActionResult Index()
        {
            return View("404");
        }
    }
}
