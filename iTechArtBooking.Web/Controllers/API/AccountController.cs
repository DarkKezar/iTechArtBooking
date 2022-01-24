using AutoMapper;
using Core.Models;
using IdentityModel;
using Infrastucture.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Text.Json;

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

                 var now = DateTime.UtcNow;
                 // создаем JWT-токен
                 var jwt = new JwtSecurityToken(
                         issuer: AuthOptions.ISSUER,
                         audience: AuthOptions.AUDIENCE,
                         notBefore: now,
                         expires: now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
                         signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
                 var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

                 var response = new
                 {
                     access_token = encodedJwt,
                     username = user.UserName
                 };

                 return Ok(new { access_token = encodedJwt, userName = user.UserName, Role = "user" });
             }
             return Unauthorized(new { Message = "Wrong login or password!!!" });
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
            await _userManager.AddToRoleAsync(user, "user");
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
