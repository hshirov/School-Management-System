﻿using Data;
using Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace Business
{
    public class StudentBll
    {
        private SchoolDbContext _dbContext;

        /// <summary>
        /// Finds the first student in the table based on the given email and password in User.
        /// </summary>
        /// <param name="user">Stores email and password.</param>
        public Student GetStudent(User user)
        {
            string password = UserBll.GetStringSha256Hash(user.PasswordHash);
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

        public List<Student> GetStudentsFromClass(int id)
        {
            Student student = GetStudent(id);
            string classLetter = student.ClassLetter;
            int classNumber = student.ClassNumber;
            List<Student> studentsFromClass;

            using (SchoolDbContext dbContext = new SchoolDbContext())
            {
                studentsFromClass = dbContext.Students.Where(x => x.ClassLetter == classLetter && x.ClassNumber == classNumber).ToList();
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
            student.PasswordHash = UserBll.GetStringSha256Hash(student.PasswordHash);
            using (_dbContext = new SchoolDbContext())
            {
                _dbContext.Students.Add(student);
                _dbContext.SaveChanges();
            }
        }
    }
}
