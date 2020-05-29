using System;
using System.Runtime.InteropServices;
using NUnit.Framework;
using SchoolManagementSystem.Controllers;
using Business;

namespace SchoolManagementSystem.NUnitTests.Controllers
{
    [TestFixture]
    public class HomeControllerTests
    {        
        [Test]
        public void Index_Student_ReturnsHomePage()
        {

        }

        [Test]
        public void Index_Teacher_ReturnsHomePage()
        {
            //TODO
            //ViewResult result = controller.Index() as ViewResult;

            //Assert.IsNotNull(result);
        }
        [Test]
        public void Index_NoUser_ReturnsLoginPage()
        {
            //TODO
            //ViewResult result = controller.Index() as ViewResult;

            //Assert.IsNotNull(result);
        }
    }
}
