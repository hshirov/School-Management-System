using Data;
using Data.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace Business
{
    public class StudentBll
    {
        private SchoolDbContext _dbContext;
        private readonly UserBll _userBll;

        public StudentBll()
        {
            _userBll = new UserBll();
        }

        /// <summary>
        /// Finds the first student in the table based on the given email and password in User.
        /// </summary>
        /// <param name="user">Stores email and password.</param>
        public Student GetStudent(User user)
        {
            string password = _userBll.HashPassword(user.PasswordHash);
            using (_dbContext = new SchoolDbContext())
            {
                Student student = _dbContext.Students.FirstOrDefault(x => x.Email == user.Email && x.PasswordHash == password);
                return student;
            }
        }

        /// <summary>
        /// Finds the first student in the table based on the given id in User.
        /// </summary>
        /// <param name="id">Stores id.</param>
        public Student GetStudent(int id)
        {
            using (_dbContext = new SchoolDbContext())
            {
                Student student = _dbContext.Students.FirstOrDefault(x => x.Id == id);
                return student;
            }
        }

        /// <summary>
        /// Returns every student from the database
        /// </summary>
        public List<Student> GetAll()
        {
            using (_dbContext = new SchoolDbContext())
            {
                List<Student> students = _dbContext.Students.ToList();
                return students;
            }
        }

        /// <summary>
        /// Finds a student with the given ID and returns every student from his class.
        /// </summary>
        public List<Student> GetStudentsFromClass(int id)
        {
            Student student = GetStudent(id);
            string classLetter = student.ClassLetter;
            int classNumber = student.ClassNumber;
            List<Student> studentsFromClass;

            using (SchoolDbContext dbContext = new SchoolDbContext())
            {
                studentsFromClass = dbContext.Students.Where(x => x.ClassLetter == classLetter && x.ClassNumber == classNumber).OrderByDescending(x => x.FirstName).ToList();
            }

            return studentsFromClass;
        }

        /// <summary>
        /// Finds a student with the given classNumber and classLetter and returns every student from his class.
        /// </summary>
        public List<Student> GetStudentsFromClass(int classNumber, string classLetter)
        {
            List<Student> studentsFromClass;
            using (SchoolDbContext dbContext = new SchoolDbContext())
            {
                studentsFromClass = dbContext.Students.Where(x => x.ClassLetter == classLetter && x.ClassNumber == classNumber).OrderByDescending(x => x.FirstName).ToList();
            }

            return studentsFromClass;
        }

        /// <summary>
        /// Turns a instance of Student to a Person, which holds all the matching parameters from students and teachers
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
                Address = student.Address,
                Role = "Student"
            };

            return person;
        }

        /// <summary>
        /// Checks if there is a student with the same email.
        /// </summary>
        public bool IsEmailInUse(string email)
        {
            using (_dbContext = new SchoolDbContext())
            {
                return _dbContext.Students.Any(x => x.Email == email);
            }
        }

        /// <summary>
        /// Adds a student profile.
        /// </summary>
        public void AddStudent(Student student)
        {
            student.PasswordHash = _userBll.HashPassword(student.PasswordHash);
            using (_dbContext = new SchoolDbContext())
            {
                _dbContext.Students.Add(student);
                _dbContext.SaveChanges();
            }
        }

        /// <summary>
        /// Updates the student profile information.
        /// </summary>
        public void UpdateStudent(Student student)
        {
            //DON'T TOUCH!
            //! THIS ADDS FIELDS THAT ARE EMPTY AND CANT BE CHANGED !
            student.Email = GetStudent(student.Id).Email;
            student.PasswordHash = GetStudent(student.Id).PasswordHash;
            student.ClassNumber = GetStudent(student.Id).ClassNumber;
            student.ClassLetter = GetStudent(student.Id).ClassLetter;
            using (_dbContext = new SchoolDbContext())
            {
                _dbContext.Students.AddOrUpdate(x => x.Id, student);
                _dbContext.SaveChanges();
            }
        }

        /// <summary>
        /// Deletes student profile.
        /// </summary>
        public void DeleteStudent(int id)
        {
            Student student = GetStudent(id);
            using (_dbContext = new SchoolDbContext())
            {
                _dbContext.Entry(student).State = EntityState.Deleted;
                _dbContext.Students.Remove(student);
                _dbContext.SaveChanges();
            }
        }

        /// <summary>
        /// Checks if the user password is a valid password.
        /// </summary>
        public bool IsPasswordValid(Student student)
        {
            string userPassword = GetStudent(student.Id).PasswordHash;
            string inputPassword = _userBll.HashPassword(student.PasswordHash);

            if (userPassword == inputPassword)
            {
                return true;
            }

            return false;
        }
    }
}