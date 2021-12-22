using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Не указано имя")]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required(ErrorMessage = "Не указан логин")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Не указан e-mail")]
        [EmailAddress(ErrorMessage = "Некорректный адрес")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Не указан пароль")]
        public string Password { get; set; }
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        public string ConfirmPassword { get; set; }
    }
}

/*
 * {
"FirstName": "Ilya",
"LastName": "Yanchilin",
"UserName": "DarkKezar",
"Email": "darkkezaring@gmail.com",
"Password": "_1K2e3z4a5r"
}
 */