using Data;
using Data.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace Business
{
    public class StudentBll : IStudentBll
    {
        private SchoolDbContext _dbContext;
        private readonly UserBll _userBll;

        public StudentBll()
        {
            _userBll = new UserBll();
        }

        public Student GetStudent(User user)
        {
            string password = _userBll.HashPassword(user.PasswordHash);
            using (_dbContext = new SchoolDbContext())
            {
                Student student = _dbContext.Students.FirstOrDefault(x => x.Email == user.Email && x.PasswordHash == password);
                return student;
            }
        }

        public Student GetStudent(int id)
        {
            using (_dbContext = new SchoolDbContext())
            {
                Student student = _dbContext.Students.FirstOrDefault(x => x.Id == id);
                return student;
            }
        }

        public List<Student> GetAll()
        {
            using (_dbContext = new SchoolDbContext())
            {
                List<Student> students = _dbContext.Students.ToList();
                return students;
            }
        }

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

        public List<Student> GetStudentsFromClass(int classNumber, string classLetter)
        {
            List<Student> studentsFromClass;
            using (SchoolDbContext dbContext = new SchoolDbContext())
            {
                studentsFromClass = dbContext.Students.Where(x => x.ClassLetter == classLetter && x.ClassNumber == classNumber).OrderByDescending(x => x.FirstName).ToList();
            }

            return studentsFromClass;
        }

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

        public bool IsEmailInUse(string email)
        {
            using (_dbContext = new SchoolDbContext())
            {
                return _dbContext.Students.Any(x => x.Email == email);
            }
        }

        public void AddStudent(Student student)
        {
            student.PasswordHash = _userBll.HashPassword(student.PasswordHash);
            using (_dbContext = new SchoolDbContext())
            {
                _dbContext.Students.Add(student);
                _dbContext.SaveChanges();
            }
        }

        public void UpdateStudent(Student student)
        {
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