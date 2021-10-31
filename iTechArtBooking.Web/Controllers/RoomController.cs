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
    public class RoomController : ControllerBase
    {

        [HttpGet]
        public List<Room> Get(int HotelId = -1)
        {
            return FakeRoomRepository.Get(HotelId);
        }
    }
}
