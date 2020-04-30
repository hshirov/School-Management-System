using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Data.Models
{
    public class Student
    {
        public int Id { get; set; }

        [DisplayName("First Name")]
        [Required(ErrorMessage = "First Name is Required.")]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        [Required(ErrorMessage = "Last Name is Required.")]
        public string LastName { get; set; }

        [DisplayName("Email")]
        [Required(ErrorMessage = "Email is Required.")]
        public string Email { get; set; }

        [DisplayName("Password")]
        [Required(ErrorMessage = "Password is Required.")]
        public string PasswordHash { get; set; }

        [DisplayName("Mobile")]
        [Required(ErrorMessage = "Mobile is Required.")]
        public string Mobile { get; set; }

        [DisplayName("Class Number")]
        [Required(ErrorMessage = "Class Number is Required.")]
        public int ClassNumber { get; set; }

        [DisplayName("Class Letter")]
        [Required(ErrorMessage = "Class Letter is Required.")]
        public string ClassLetter { get; set; }
    }
}
