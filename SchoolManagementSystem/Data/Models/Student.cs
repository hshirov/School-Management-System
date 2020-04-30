using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Data.Models
{
    public class Student
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

        [DisplayName("Class Number")]
        [Required(ErrorMessage = "This field is required.")]
        public int ClassNumber { get; set; }

        [DisplayName("Class Letter")]
        [Required(ErrorMessage = "This field is required.")]
        public string ClassLetter { get; set; }
    }
}
