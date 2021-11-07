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
    public class CommentController : ControllerBase
    {

        [HttpPost]
        public bool Add([Required] int hotelId, 
                           [Required] int userId, 
                           [Required] string comment, 
                           [Required] SByte mark)
        {
            return CommentRepository.Add(hotelId, userId, comment, mark);
        }

        [HttpGet]
        public List<Comment> Get([Required]int hotelId)
        {
            return CommentRepository.GetAll(hotelId);
        }
    }
}
