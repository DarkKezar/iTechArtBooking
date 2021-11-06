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
    public class HotelController : ControllerBase
    {
        //change bool to HttpCode
        [HttpPost]
        public bool Add([Required]string name)
        {
            return HotelRepository.Add(name);
        }
        [HttpDelete]
        public bool Delete([Required] int id)
        {
            return HotelRepository.DeleteById(id);
        }

        [HttpGet]
        public Hotel Get(int id = 1)
        {
            return HotelRepository.GetById(id);
        }
    }
}
