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
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    [Controller]
    public class HotelController : Microsoft.AspNetCore.Mvc.ControllerBase
    {
        private HotelRepository Repository;

        public HotelController()
        {
            Repository = new HotelRepository();
        }

        [Microsoft.AspNetCore.Authorization.Authorize(Roles = "admin")]
        [Microsoft.AspNetCore.Mvc.HttpPost]
        public async Task<HttpStatusCodeResult> Add([Required]string name)
        {
            return await Repository.Add(name);
        }
        [Microsoft.AspNetCore.Authorization.Authorize(Roles = "admin")]
        [Microsoft.AspNetCore.Mvc.HttpDelete]
        public async Task<HttpStatusCodeResult> Delete([Required] int id)
        {
            return await Repository.Delete(id);
        }

        [Microsoft.AspNetCore.Mvc.HttpGet]
        public async Task<Hotel> Get(int id = 1)
        {
            return await Repository.Get(id);
        }
    }
}
