using Core.Models;
using Infrastucture.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace iTechArtBooking.Web.Controllers
{
    [Microsoft.AspNetCore.Authorization.Authorize]
    [Microsoft.AspNetCore.Components.Route("api/[controller]")]
    [Controller]
    public class CommentController : Microsoft.AspNetCore.Mvc.ControllerBase
    {

        private CommentRepository Repository;

        public CommentController()
        {
            Repository = new CommentRepository();
        }

        [Microsoft.AspNetCore.Mvc.HttpPost]
        public async Task<HttpStatusCodeResult> Add([Required] int hotelId,
                                                    [Required] int userId,
                                                    [Required] string comment,
                                                    [Required][Range(1,5)] Byte mark)
        {
            return await Repository.Add(hotelId, userId, comment, mark);
        }

        [Microsoft.AspNetCore.Mvc.HttpGet]
        public async Task<List<Comment>> Get([Required]int hotelId)
        {
            return await Repository.Get(hotelId);
        }
    }
}
