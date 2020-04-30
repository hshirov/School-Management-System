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
        [Required(ErrorMessage = "This field is required.")]
        public string Email { get; set; }

        [DisplayName("Password")]
        [Required(ErrorMessage = "This field is required.")]
        [DataType(DataType.Password)]
        public string PasswordHash { get; set; }
    }
}
