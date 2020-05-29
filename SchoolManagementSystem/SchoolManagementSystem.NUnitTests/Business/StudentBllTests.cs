using Business;
using Data.Models;
using Moq;
using NUnit.Framework;
using System.Linq;

namespace SchoolManagementSystem.NUnitTests.Business
{
    [TestFixture]
    class StudentBllTests
    {
        [Test]
        public void GetAll_Contains_ListOfStudents()
        {
            //this is retarded
            Mock<IStudentBll> studentBllMock = new Mock<IStudentBll>();
            studentBllMock.Setup(m => m.GetAll()).Returns(new Student[] 
            {
                new Student{Id = 1, Email="hivanov@abv.bg", FirstName = "Hristo", LastName = "Ivanov", 
                    ClassNumber = 10, ClassLetter = "G", Mobile = "0009996662", Address = "Drujba, 7", PasswordHash = "pa$$w0rd"},
                new Student{Id = 2, Email="stoqn1337@abv.bg", FirstName = "Stoqn", LastName = "Stoqnov",
                    ClassNumber = 12, ClassLetter = "A", Mobile = "0009991112", Address = "Sini Kamuni, 3", PasswordHash = "foo_bar99"},
                new Student{Id = 3, Email="petarthepetar@abv.bg", FirstName = "Petar", LastName = "Uzunov",
                    ClassNumber = 12, ClassLetter = "D", Mobile = "1119991112", Address = "Mladost, 12", PasswordHash = "securepassword123"}
            }.ToList());

            var result = studentBllMock.Object.GetAll();

            Assert.IsNotNull(result);
        }
    }
}
