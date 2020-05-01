using Data;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class TeacherBLL
    {
        private SchoolDbContext dbContext;

        /// <summary>
        /// Finds the first teacher in the table based on the given email and password in User.
        /// </summary>
        /// <param name="user">Stores email and password.</param>
        public Teacher GetTeacher(User user)
        {
            using (dbContext = new SchoolDbContext())
            {
                Teacher teacher = dbContext.Teachers.Where(x => x.Email == user.Email && x.PasswordHash == user.PasswordHash).FirstOrDefault();
                return teacher;
            }
        }
        public bool IsEmailInUse(string email)
        {
            using (dbContext = new SchoolDbContext())
            {
                return dbContext.Teachers.Any(x => x.Email == email);
            }
        }
    }
}
