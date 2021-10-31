using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastucture.Repositories.Fake
{
    public class FakeUserRepository
    {
        public static User Get(int UserId)
        {
            var User = new User();
            User.Id = UserId;
            User.Name = "UserName_" + UserId;
            return User;
        }
    }
}
