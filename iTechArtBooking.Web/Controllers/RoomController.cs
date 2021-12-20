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
    public class RoomController : Microsoft.AspNetCore.Mvc.ControllerBase
    {
        private RoomRepository Repository;

        public RoomController()
        {
            Repository = new RoomRepository();
        }

        [Microsoft.AspNetCore.Mvc.HttpPost]
        public async Task<HttpStatusCodeResult> Add([Required]int hotelId, [Required]string name, uint cost)
        {
            return await Repository.Add(hotelId, name, cost);
        }

        [Microsoft.AspNetCore.Mvc.HttpGet]
        public async Task<Room> Get([Required]int id)
        {
            return await Repository.Get(id);
        }
    }
}
