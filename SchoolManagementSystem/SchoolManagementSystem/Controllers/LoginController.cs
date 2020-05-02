using Business;
using Data;
using Data.Models;
using System.Web.Mvc;

namespace SchoolManagementSystem.Controllers
{
    public class LoginController : Controller
    {
        private StudentBLL studentBLL = new StudentBLL();
        private TeacherBLL teacherBLL = new TeacherBLL();

        // GET: Login
        public ActionResult Index()
        {
            //If you're logged in, you can't access this view
            if (Session["studentID"] != null || Session["teacherID"] != null) 
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost]
        public ActionResult Authorize(User user)
        {
            using(SchoolDbContext db = new SchoolDbContext())
            {
                var studentDetails = studentBLL.GetStudent(user);
                var teacherDetails = teacherBLL.GetTeacher(user);

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