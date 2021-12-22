using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace iTechArtBooking.Web.Controllers.Front
{
    [Authorize(Roles = "admin")]
    [Route("/booked")]
    [Controller]
    public class BookedController : Controller
    {
        public IActionResult Index()
        {
            return View("booked");
        }
    }
}
