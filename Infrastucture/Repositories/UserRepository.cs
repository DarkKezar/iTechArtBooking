using Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;


namespace Infrastucture.Repositories
{

    public class UserRepository
    {
        
        public async Task<List<User>> Get()
        {
            using(var db = new BookingContext())
            {
                var Users = db.Users.ToListAsync();
                return await Users;
            }
        }
    }
}
