using Core.Models;
using Infrastucture.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace iTechArtBooking.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        [HttpPost]
        public bool Add([Required]int hotelId, [Required]string name, uint cost)
        {
            return RoomRepository.Add(hotelId, name, cost);
        }

        [HttpGet]
        public Room Get([Required]int id)
        {
            return RoomRepository.GetById(id);
        }
    }
}
