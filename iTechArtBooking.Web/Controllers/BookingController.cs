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
    public class BookingController : Microsoft.AspNetCore.Mvc.ControllerBase
    {
        private BookingRepository Repository;

        public BookingController()
        {
            Repository = new BookingRepository();
        }

        [Microsoft.AspNetCore.Mvc.HttpPost]
        public async Task<HttpStatusCodeResult> Add([Required] int roomId, 
                                                    [Required] int userId, 
                                                    [Required] DateTime date, 
                                                    [Required] Byte period)
        {
            return await Repository.Add(roomId, userId, date, period);
        }

        [Microsoft.AspNetCore.Mvc.HttpDelete]
        public async Task<HttpStatusCodeResult> Delete([Required] int id)
        {
            return await Repository.Delete(id);
        }

        [Microsoft.AspNetCore.Mvc.HttpGet]
        public async Task<List<Booking>> Get([Required]int userId)
        {
            return await Repository.Get(userId);
        }
    }
}
