using Business;
using Data.Models;
using System.Web.Mvc;

namespace SchoolManagementSystem.Controllers
{
    public class LoginController : Controller
    {
        private readonly StudentBll _studentBll;
        private readonly TeacherBll _teacherBll;

        public LoginController()
        {
            _studentBll = new StudentBll();
            _teacherBll = new TeacherBll();
        }
        public ActionResult Index()
        {
            //If you're logged in, you can't access this view
            if (Session["studentID"] != null || Session["teacherID"] != null) 
            {
                return RedirectToAction("Index", "Home");
            }
            else if(Session["adminID"] != null)
            {
                return RedirectToAction("Index", "AdminPanel");
            }
            return View();
        }

        [HttpPost]
        public ActionResult Authorize(User user)
        {
            if(user.Email == "admin@sms.com" && user.PasswordHash == "admin")
            {
                Session["adminID"] = 1;//Id
                return RedirectToAction("Index", "AdminPanel");
            }

            var studentDetails = _studentBll.GetStudent(user);
            var teacherDetails = _teacherBll.GetTeacher(user);
            Session.Clear();

            if (studentDetails != null)
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
            else
            {
                //user not found
                ViewData["Message"] = "Error";
                return View("Index");
            }                        
        }

        public ActionResult LogOut()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
    }
}