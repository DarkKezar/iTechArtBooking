﻿using Core.Models;
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
    public class BookedController : ControllerBase
    {

        [HttpGet]
        public List<Booked> Get(int RoomId)
        {
            return new List<Booked>();
        }
    }
}
