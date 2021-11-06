using Core.Models;
using Infrastucture.Repositories;
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
    public class HotelsController : ControllerBase
    {

        [HttpGet]
        public List<Hotel> Get(int count = 1, int from = 1)
        {
            return HotelRepository.GetAll(count, from);
        }
    }
}
