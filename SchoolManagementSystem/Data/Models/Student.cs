using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Data.Models
{
    public class Student
    {
        public int Id { get; set; }

        [DisplayName("First Name")]
        [Required(ErrorMessage = "First Name is Required.")]
        [StringLength(15, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        [Required(ErrorMessage = "Last Name is Required.")]
        [StringLength(15, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string LastName { get; set; }

        [DisplayName("Email")]
        [EmailAddress]
        [Required(ErrorMessage = "Email is Required.")]
        public string Email { get; set; }

        [DisplayName("Password")]
        [Required(ErrorMessage = "Password is Required.")]
        [DataType(DataType.Password)]
        [StringLength(30, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 5)]
        public string PasswordHash { get; set; }

        [DisplayName("Mobile")]
        [Phone]
        [Required(ErrorMessage = "Mobile is Required.")]
        [StringLength(10, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 9)]
        public string Mobile { get; set; }

        [DisplayName("Class Number")]
        [Required(ErrorMessage = "Class Number is Required.")]
        public int ClassNumber { get; set; }

        [DisplayName("Class Letter")]
        [Required(ErrorMessage = "Class Letter is Required.")]
        public string ClassLetter { get; set; }
    }
}
