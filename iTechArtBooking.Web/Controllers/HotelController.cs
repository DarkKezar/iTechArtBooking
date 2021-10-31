using Core.Models;
using Infrastucture.Repositories.Fake;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iTechArtBooking.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {

        [HttpGet]
        public List<Hotel> Get(int Count = -1, int From = 0)
        {
            return FakeHotelRepository.Get(Count, From);
        }
    }
}
