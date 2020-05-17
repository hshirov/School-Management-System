using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Data.Models
{
    public class Student
    {
        public int Id { get; set; }

        [DisplayName("First Name")]
        [Required(ErrorMessage = "First Name is Required!")]
        [StringLength(15, ErrorMessage = "{0} length must be between {2} and {1}!", MinimumLength = 3)]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please.")]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        [Required(ErrorMessage = "Last Name is Required!")]
        [StringLength(15, ErrorMessage = "{0} length must be between {2} and {1}!", MinimumLength = 3)]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please.")]
        public string LastName { get; set; }

        [DisplayName("Email")]
        [EmailAddress]
        [Required(ErrorMessage = "Email is Required!")]
        [Remote("VerifyEmail", "Register", ErrorMessage = "Email already in use!")]
        public string Email { get; set; }

        [DisplayName("Password")]
        [Required(ErrorMessage = "Password is Required!")]
        [DataType(DataType.Password)]
        [StringLength(64, ErrorMessage = "{0} length must be between {2} and {1}!", MinimumLength = 5)]
        public string PasswordHash { get; set; }

        [DisplayName("Mobile")]
        [Phone]
        [Required(ErrorMessage = "Mobile is Required!")]
        [StringLength(10, ErrorMessage = "{0} length must be between {2} and {1}!", MinimumLength = 9)]
        [Range(011111111, 0999999999, ErrorMessage = "Please enter a valid Mobile number!")]
        [DataType(DataType.PhoneNumber)]
        public string Mobile { get; set; }

        [DisplayName("Address")]
        [Required(ErrorMessage = "Address is Required!")]
        [StringLength(50, ErrorMessage = "{0} length must be between {2} and {1}!", MinimumLength = 6)]
        public string Address { get; set; }

        [DisplayName("Class Number")]
        [Required(ErrorMessage = "Class Number is Required!")]
        public int ClassNumber { get; set; }

        [DisplayName("Class Letter")]
        [Required(ErrorMessage = "Class Letter is Required!")]
        public string ClassLetter { get; set; }
    }
}