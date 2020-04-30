

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Data.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        [DisplayName("First Name")]
        [Required(ErrorMessage = "This field is required.")]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        [Required(ErrorMessage = "This field is required.")]
        public string LastName { get; set; }

        [DisplayName("Email")]
        [Required(ErrorMessage = "This field is required.")]
        public string Email { get; set; }

        [DisplayName("Password")]
        [Required(ErrorMessage = "This field is required.")]
        public string PasswordHash { get; set; }

        [DisplayName("Mobile")]
        [Required(ErrorMessage = "This field is required.")]
        public string Mobile { get; set; }

        [DisplayName("Subject")]
        [Required(ErrorMessage = "This field is required.")]
        public string Subject { get; set; }
    }
}
