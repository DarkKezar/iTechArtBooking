using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace iTechArtBooking.Web.Controllers.Front
{
    [Authorize]
    [Route("/catalog")]
    [Controller]
    public class CatalogController : Controller
    {
        public IActionResult Index()
        {
            return View("catalog");
        }
    }
}
