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
            string password = UserBLL.GetStringSha256Hash(user.PasswordHash);
            using (dbContext = new SchoolDbContext())
            {
                Teacher teacher = dbContext.Teachers.Where(x => x.Email == user.Email && x.PasswordHash == password).FirstOrDefault();
                return teacher;
            }
        }

        public Teacher GetTeacher(int id)
        {
            using (dbContext = new SchoolDbContext())
            {
                Teacher teacher = dbContext.Teachers.Where(x => x.Id == id).FirstOrDefault();
                return teacher;
            }
        }

        /// <summary>
        /// Turns a instance of Teacher to a Person, which holds all the metching parameters from students and teachers
        /// </summary>
        public Person GetPerson(int id)
        {
            Teacher teacher = GetTeacher(id);
            Person person = new Person
            {
                Id = teacher.Id,
                FirstName = teacher.FirstName,
                LastName = teacher.LastName,
                Email = teacher.Email,
                Mobile = teacher.Mobile
            };

            return person;
        }

        public bool IsEmailInUse(string email)
        {
            using (dbContext = new SchoolDbContext())
            {
                return dbContext.Teachers.Any(x => x.Email == email);
            }
        }

        public void AddTeacher(Teacher teacher)
        {
            teacher.PasswordHash = UserBLL.GetStringSha256Hash(teacher.PasswordHash);
            using (dbContext = new SchoolDbContext())
            {
                dbContext.Teachers.Add(teacher);
                dbContext.SaveChanges();
            }
        }
    }
}
