using Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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
        
        public static List<User> GetAll()
        {
            using(var db = new BookingContext())
            {
                var Users = db.Users.ToList();
                return Users;
            }
        }
    }
}
