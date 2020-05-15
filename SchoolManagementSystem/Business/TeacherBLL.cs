using Data;
using Data.Models;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace Business
{
    public class TeacherBll
    {
        private SchoolDbContext _dbContext;
        private readonly UserBll _userBll;

        public TeacherBll()
        {
            _userBll = new UserBll();
        }

        /// <summary>
        /// Finds the first teacher in the table based on the given email and password in User.
        /// </summary>
        /// <param name="user">Stores email and password.</param>
        public Teacher GetTeacher(User user)
        {
            string password = _userBll.HashPassword(user.PasswordHash);
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
                Address = teacher.Address,
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
            teacher.PasswordHash = _userBll.HashPassword(teacher.PasswordHash);
            using (_dbContext = new SchoolDbContext())
            {
                _dbContext.Teachers.Add(teacher);
                _dbContext.SaveChanges();
            }
        }

        public void UpdateTeacher(Teacher teacher)
        {
            //DON'T TOUCH!
            //! THIS ADDS FIELDS THAT ARE EMPTY AND CANT BE CHANGED !
            teacher.Email = GetTeacher(teacher.Id).Email;
            teacher.PasswordHash = GetTeacher(teacher.Id).PasswordHash;
            teacher.Subject = GetTeacher(teacher.Id).Subject;
            using (_dbContext = new SchoolDbContext())
            {
                _dbContext.Teachers.AddOrUpdate(x => x.Id, teacher);
                _dbContext.SaveChanges();
            }
        }

        public void DeleteTeacher(int id)
        {
            Teacher teacher = GetTeacher(id);
            using (_dbContext = new SchoolDbContext())
            {
                _dbContext.Entry(teacher).State = EntityState.Deleted;
                _dbContext.Teachers.Remove(teacher);
                _dbContext.SaveChanges();
            }
        }

        public bool IsPasswordValid(Teacher teacher)
        {
            string userPassword = GetTeacher(teacher.Id).PasswordHash;
            string inputPassword = _userBll.HashPassword(teacher.PasswordHash);

            if (userPassword == inputPassword)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}