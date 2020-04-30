using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class User
    {
        [DisplayName("Email")]
        [Required(ErrorMessage = "Email is Required.")]
        public string Email { get; set; }

        [DisplayName("Password")]
        [Required(ErrorMessage = "Password is Required.")]
        [DataType(DataType.Password)]
        public string PasswordHash { get; set; }
        public string LoginErrorMessage { get; set; }
    }
}
