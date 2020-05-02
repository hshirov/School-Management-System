using Data;
using Data.Models;
using System.Linq;

namespace Business
{
    public class TeacherBll
    {
        private SchoolDbContext _dbContext;

        /// <summary>
        /// Finds the first teacher in the table based on the given email and password in User.
        /// </summary>
        /// <param name="user">Stores email and password.</param>
        public Teacher GetTeacher(User user)
        {
            string password = UserBll.GetStringSha256Hash(user.PasswordHash);
            using (_dbContext = new SchoolDbContext())
            {
                Teacher teacher = _dbContext.Teachers.FirstOrDefault(x => x.Email == user.Email && x.PasswordHash == password);
                return teacher;
            }
        }

        public Teacher GetTeacher(int id)
        {
            using (_dbContext = new SchoolDbContext())
            {
                Teacher teacher = _dbContext.Teachers.FirstOrDefault(x => x.Id == id);
                return teacher;
            }
        }

        /// <summary>
        /// Turns a instance of Teacher to a Person, which holds all the matching parameters from students and teachers
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
                Mobile = teacher.Mobile,
                Role = "Teacher"
            };

            return person;
        }

        public bool IsEmailInUse(string email)
        {
            using (_dbContext = new SchoolDbContext())
            {
                return _dbContext.Teachers.Any(x => x.Email == email);
            }
        }

        public void AddTeacher(Teacher teacher)
        {
            teacher.PasswordHash = UserBll.GetStringSha256Hash(teacher.PasswordHash);
            using (_dbContext = new SchoolDbContext())
            {
                _dbContext.Teachers.Add(teacher);
                _dbContext.SaveChanges();
            }
        }
    }
}
