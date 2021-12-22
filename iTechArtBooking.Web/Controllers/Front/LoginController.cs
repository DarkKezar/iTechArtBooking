using Microsoft.AspNetCore.Mvc;

namespace iTechArtBooking.Web.Controllers.Front
{
    [Route("/Account/Login")]
    [Controller]
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View("login");
        }
    }
}
