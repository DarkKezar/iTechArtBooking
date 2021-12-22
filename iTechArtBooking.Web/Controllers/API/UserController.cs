using Core.Models;
using Infrastucture.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iTechArtBooking.Web.Controllers
{
    [Route("api/[controller]")]
    [Controller]
    public class UserController : ControllerBase
    {

        private UserRepository Repository;

        public UserController()
        {
            Repository = new UserRepository();
        }
        [Microsoft.AspNetCore.Authorization.Authorize(Roles = "admin")]
        [HttpGet]
        public async Task<List<User>> Get()
        {
            return await Repository.Get();
        }
    }
}
