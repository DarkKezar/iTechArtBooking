using Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastucture.Repositories
{

    public class UserRepository
    {
        private static UserManager<User> _userManager;
        private static string hash(string a)
        {
            return a + a;
        }
        public static List<User> GetAll()
        {
            using(var db = new BookingContext())
            {
                var Users = db.Users.ToList();
                return Users;
            }
        }

        public static async Task<bool> Register(RegisterModel model)
        {
            var User = new User();
            User.FirstName = model.FirstName;
            User.LastName = model.LastName;
            User.UserName = model.UserName;
            User.Email = model.Email;

            var result = await _userManager.CreateAsync(User, model.Password);
            if (result == null) return false;
            return true;
        }
    }
}
