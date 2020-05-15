using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Data.Models
{
    public class User
    {
        [DisplayName("Email")]
        [Required(ErrorMessage = "Email is Required!")]
        public string Email { get; set; }

        [DisplayName("Password")]
        [Required(ErrorMessage = "Password is Required!")]
        [DataType(DataType.Password)]
        public string PasswordHash { get; set; }
    }
}