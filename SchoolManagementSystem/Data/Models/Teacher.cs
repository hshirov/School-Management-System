

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Data.Models
{
    public class Teacher
    {
        public int Id { get; set; }

        [DisplayName("First Name")]
        [Required(ErrorMessage = "First Name is Required.")]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        [Required(ErrorMessage = "Last Name is Required.")]
        public string LastName { get; set; }

        [DisplayName("Email")]
        [EmailAddress]
        [Required(ErrorMessage = "Email is Required.")]
        public string Email { get; set; }

        [DisplayName("Password")]
        [Required(ErrorMessage = "Password is Required.")]
        [DataType(DataType.Password)]
        public string PasswordHash { get; set; }

        [DisplayName("Mobile")]
        [Phone]
        [Required(ErrorMessage = "Mobile is Required.")]
        public string Mobile { get; set; }

        [DisplayName("Subject")]
        [Required(ErrorMessage = "This field is required.")]
        public string Subject { get; set; }
    }
}
