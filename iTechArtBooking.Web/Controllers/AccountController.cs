using AutoMapper;
using Core.Models;
using Infrastucture.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace iTechArtBooking.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {

        private readonly UserManager<User> _userManager;

        public AccountController(UserManager<User> userManager)
        {
            _userManager = userManager ?? throw new ArgumentException("Invalid argument.");
        }

        [Route("log-in")]
        [HttpPost]
        public async Task<IActionResult> Login([Required] LoginModel model)
        {
            var user = await _userManager.FindByNameAsync(model.UserName);
            if (user != null &&
                await _userManager.CheckPasswordAsync(user, model.Password))
            {
                var authClaims = new List<Claim>();

                var token = new JwtSecurityToken(/*token data*/);

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo,
                    id = user.Id
                });
            }
            return Unauthorized(new { Message = "Wrong email or password!!!" });
        }

        [Route("sign-in")]
        [HttpPost]
        public async Task<IActionResult> Register([Required] RegisterModel model)
        {
            var user = ModelToUser(model);
            using (var db = new BookingContext())
            {
                if (db.Users.Count(u => u.Email == user.Email ||
                                        u.NormalizedUserName == user.UserName.ToUpper()) != 0) 
                    return StatusCode(
                        StatusCodes.Status500InternalServerError,
                        new { Message = "Email is already used!" });
            }

            var result = await _userManager.CreateAsync(user, model.Password);
            if (result == null) return StatusCode(
                        StatusCodes.Status500InternalServerError,
                        new
                        {
                            Message = "User creation failed!",
                            Errors = result.Errors
                        });
            return Ok(new
            {
                Status = "Success",
                Message = "User created successfully!"
            }); 
        }

        private User ModelToUser(RegisterModel model)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<RegisterModel, User>());
            var mapper = new Mapper(config);
            var User = mapper.Map<RegisterModel, User>(model);

            return User;
        }

    }
}
