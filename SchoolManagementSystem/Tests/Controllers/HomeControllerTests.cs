using System;
using System.Runtime.InteropServices;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SchoolManagementSystem.Controllers;
using Business;

namespace Tests.Controllers
{
    [TestClass]
    public class HomeControllerTests
    {
        HomeController controller = new HomeController();
        [TestMethod]
        public void Index_Student_ReturnsHomePage()
        {
            //TODO
            ViewResult result = controller.Index() as ViewResult;

            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void Index_Teacher_ReturnsHomePage()
        {
            //TODO
            ViewResult result = controller.Index() as ViewResult;

            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void Index_NoUser_ReturnsLoginPage()
        {
            //TODO
            ViewResult result = controller.Index() as ViewResult;

            Assert.IsNotNull(result);
        }
    }
}
