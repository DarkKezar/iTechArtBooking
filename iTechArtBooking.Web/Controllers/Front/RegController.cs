using Microsoft.AspNetCore.Mvc;

namespace iTechArtBooking.Web.Controllers.Front
{
    [Route("Account/Signin")]
    [Controller]
    public class RegController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View("reg");
        }
    }
}
