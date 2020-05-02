using Data;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class StudentBLL
    {
        private SchoolDbContext dbContext;

        /// <summary>
        /// Finds the first student in the table based on the given email and password in User.
        /// </summary>
        /// <param name="user">Stores email and password.</param>
        public Student GetStudent(User user)
        {
            string password = UserBLL.GetStringSha256Hash(user.PasswordHash);
            using (dbContext = new SchoolDbContext())
            {
                Student student = dbContext.Students.Where(x => x.Email == user.Email && x.PasswordHash == password).FirstOrDefault();
                return student;
            }
        }
        public Student GetStudent(int id)
        {
            using (dbContext = new SchoolDbContext())
            {
                Student student = dbContext.Students.Where(x => x.Id == id).FirstOrDefault();
                return student;
            }
        }

        public List<Student> GetStudentsFromClass(int id)
        {
            Student student = GetStudent(id);
            string classLetter = student.ClassLetter;
            int classNumber = student.ClassNumber;
            List<Student> studentsFromClass = new List<Student>();

            using (dbContext = new SchoolDbContext())
            {
                studentsFromClass = dbContext.Students.Where(x => x.ClassNumber == classNumber && x.ClassNumber == classNumber).ToList();
            }

            return studentsFromClass;
        }

        /// <summary>
        /// Turns a instance of Student to a Person, which holds all the metching parameters from students and teachers
        /// </summary>
        public Person GetPerson(int id)
        {
            Student student = GetStudent(id);
            Person person = new Person
            {
                Id = student.Id,
                FirstName = student.FirstName,
                LastName = student.LastName,
                Email = student.Email,
                Mobile = student.Mobile,
                Role = "Student"
            };

            return person;
        }

        public bool IsEmailInUse(string email)
        {
            using (dbContext = new SchoolDbContext())
            {
                return dbContext.Students.Any(x => x.Email == email);
            }
        }

        public void AddStudent(Student student)
        {
            student.PasswordHash = UserBLL.GetStringSha256Hash(student.PasswordHash);
            using (dbContext = new SchoolDbContext())
            {
                dbContext.Students.Add(student);
                dbContext.SaveChanges();
            }
        }
    }
}
