using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Data;
using Business;

namespace SchoolManagementSystem.Controllers
{
    public class LoginController : Controller
    {
        private StudentBLL StudentBLL = new StudentBLL();
        private TeacherBLL TeacherBLL = new TeacherBLL();
        // GET: Login
        public ActionResult Index()
        {           
            return View();
        }

        [HttpPost]
        public ActionResult Authorize(User user)
        {
            using(SchoolDbContext db = new SchoolDbContext())
            {
                var studentDetails = StudentBLL.GetStudent(user);
                var teacherDetails = TeacherBLL.GetTeacher(user);

                if (studentDetails == null && teacherDetails == null)
                {
                    //user not found
                    user.LoginErrorMessage = "Wrong email or password.";
                    return View("Index", user);
                }
                else if (studentDetails != null)
                {
                    //student found
                    Session["studentID"] = studentDetails.Id;
                    return RedirectToAction("Index", "Home");
                }
                else if(teacherDetails != null)
                {
                    //teacher found
                    Session["teacherID"] = teacherDetails.Id;
                    return RedirectToAction("Index", "Home");
                }
            }

            return View();
        }

        public ActionResult LogOut()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
    }
}