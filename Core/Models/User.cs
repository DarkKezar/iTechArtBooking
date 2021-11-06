using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class User : IdentityUser
    {
        //public long Id { get; set; } 
        //Is is in Identity
        public string FirstName { get; set; }
        public string LastName { get; set; }

        /*
            IdentityUser fields:
             1. Id
             2. UserName
             3. Claims
             4. Email
             5. PasswordHash
             6. Roles
             7. PhoneNumber
             8. SecurityStamp
        */
    }
}
