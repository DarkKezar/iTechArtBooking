using Core.Models;
using Infrastucture.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iTechArtBooking.Web.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [Controller]
    public class HotelsController : ControllerBase
    {
        private HotelRepository Repository;

        public HotelsController()
        {
            Repository = new HotelRepository();
        }
        [HttpGet]
        public async Task<List<Hotel>> Get(int count = 0, int from = 1)
        {
            return await Repository.Get(count, from);
        }
    }
}
