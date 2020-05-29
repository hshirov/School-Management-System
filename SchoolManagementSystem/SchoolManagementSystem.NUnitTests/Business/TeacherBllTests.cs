using Business;
using Data.Models;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SchoolManagementSystem.NUnitTests.Business
{
    [TestFixture]
    class TeacherBllTests
    {
        [Test]
        public void GetAll_Contains_ListOfTeachers()
        {
            Mock<ITeacherBll> teacherBllMock = new Mock<ITeacherBll>();
            teacherBllMock.Setup(m => m.GetAll()).Returns(new Teacher[] 
            { 
                new Teacher{Id = 1, Email = "emil1@gmail.com", FirstName = "Emil", LastName = "Markov", Subject = "Maths", Mobile = "0899023232", 
                Address = "Drujba, 14", PasswordHash = "themostsecurepasswordever"},
                new Teacher{Id = 2, Email = "antonee@gmail.com", FirstName = "Anton", LastName = "Donev", Subject = "Arts", Mobile = "0899237221",
                Address = "Republika, 4", PasswordHash = "bigbrother1984"}
            }.ToList());

            var result = teacherBllMock.Object.GetAll();

            Assert.IsNotNull(result);
        }
    }
}
