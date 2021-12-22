using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class LoginModel 
    {
        [Required(ErrorMessage = "Не указан логин")]
        public string UserName;
        [Required(ErrorMessage = "Не указан пароль")]
        public string Password;
    }
}
