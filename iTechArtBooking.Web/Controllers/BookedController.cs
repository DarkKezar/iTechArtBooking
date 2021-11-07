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
    public class BookedController : ControllerBase
    {

        [HttpPost]
        public bool Add([Required] int roomId, 
                        [Required] int userId, 
                        [Required] DateTime date, 
                        [Required] SByte period)
        {
            return BookedRepository.Add(roomId, userId, date, period);
        }

        [HttpDelete]
        public bool Delete([Required] int id)
        {
            return BookedRepository.Delete(id);
        }

        [HttpGet]
        public List<Booked> Get([Required]int userId)
        {
            return BookedRepository.GetAll(userId);
        }
    }
}
