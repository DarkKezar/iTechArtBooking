using Core.Models;
using Infrastucture.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace iTechArtBooking.Web.Controllers
{
    [Microsoft.AspNetCore.Authorization.Authorize]
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    [Controller]
    public class BookingController : Microsoft.AspNetCore.Mvc.ControllerBase
    {
        private BookingRepository Repository;
        private UserManager<User> _userManager;

        public BookingController(UserManager<User> userManager)
        {
            Repository = new BookingRepository();
            _userManager = userManager ?? throw new ArgumentException("Invalid argument.");
        }

        [Microsoft.AspNetCore.Mvc.HttpPost]
        public async Task<HttpStatusCodeResult> Add([Required] int roomId, 
                                                    //[Required] int userId, 
                                                    [Required] DateTime startDate, 
                                                    [Required] DateTime endDate 
                                                    )
        {
            return await Repository.Add(roomId, (await _userManager.GetUserAsync(HttpContext.User)).Id, startDate, endDate);
        }

        [Microsoft.AspNetCore.Mvc.HttpDelete]
        public async Task<HttpStatusCodeResult> Delete([Required] int id)
        {
            return await Repository.Delete(id);
        }

        [Microsoft.AspNetCore.Mvc.HttpGet]
        //public async Task<List<Booking>> Get([Required]int userId)
        public async Task<List<Booking>> Get()
        {
            return await Repository.Get((await _userManager.GetUserAsync(HttpContext.User)).Id);
        }
    }
}
