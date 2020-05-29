using Business;
using Data.Models;
using System.Web.Mvc;

namespace SchoolManagementSystem.Controllers
{
    public class LoginController : Controller
    {
        private readonly IStudentBll _studentBll;
        private readonly ITeacherBll _teacherBll;

        public LoginController()
        {
            _studentBll = new StudentBll();
            _teacherBll = new TeacherBll();
        }

        /// <summary>
        /// If you're logged in, you can't access this view.
        /// Checks session id and redirects to View redirection.
        /// </summary>
        /// <returns>To View redirection according to session or admin panel.</returns>
        public ActionResult Index()
        {
            if (Session["studentID"] != null || Session["teacherID"] != null) 
            {
                return RedirectToAction("Index", "Home");
            }

            if (Session["adminID"] != null)
            {
                return RedirectToAction("Index", "AdminPanel");
            }
            return View();
        }

        /// <summary>
        /// Authorizes the user details and creating user session id by their role.
        /// </summary>
        /// <param name="user">Stores user information.</param>
        /// <returns>To View redirection according to session or admin panel or error.</returns>
        [HttpPost]
        public ActionResult Authorize(User user)
        {
            if (user.Email == "admin@sms.com" && user.PasswordHash == "admin")
            {
                //admin recognition success
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

            if (teacherDetails != null)
            {
                //teacher found
                Session["teacherID"] = teacherDetails.Id;
                return RedirectToAction("Index", "Home");
            }
            
            //user not found
            ViewData["Message"] = "Error";
            return View("Index");
        }

       /// <summary>
       /// Logs out from the current profile.
       /// </summary>
       /// <returns>To Login session redirection.</returns>
        public ActionResult LogOut()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
    }
}