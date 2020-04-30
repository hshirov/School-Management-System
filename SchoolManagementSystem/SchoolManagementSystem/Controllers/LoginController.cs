using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Data;

namespace SchoolManagementSystem.Controllers
{
    public class LoginController : Controller
    {
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
                var studentDetails = db.Students.Where(x => x.Email == user.Email && x.PasswordHash == user.PasswordHash).FirstOrDefault();
                var teacherDetails = db.Teachers.Where(x => x.Email == user.Email && x.PasswordHash == user.PasswordHash).FirstOrDefault();

                if (studentDetails == null && teacherDetails == null)
                {
                    //user not found
                    user.LoginErrorMessage = "User not found.";
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