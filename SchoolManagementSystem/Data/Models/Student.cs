using System.ComponentModel;

namespace Data.Models
{
    public class Student
    {
        public int Id { get; set; }
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [DisplayName("Email")]
        public string Email { get; set; }

        [DisplayName("Password")]
        public string PasswordHash { get; set; }

        [DisplayName("Mobile")]
        public string Mobile { get; set; }

        [DisplayName("Class Number")]
        public int ClassNumber { get; set; }

        [DisplayName("Class Letter")]
        public string ClassLetter { get; set; }
    }
}
