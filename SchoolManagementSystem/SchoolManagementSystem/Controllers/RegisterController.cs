using Business;
using Data;
using Data.Models;
using System.Web.Mvc;

namespace SchoolManagementSystem.Controllers
{
    public class RegisterController : Controller
    {
        private readonly IStudentBll _studentBll;
        private readonly ITeacherBll _teacherBll;

        public RegisterController()
        {
            _studentBll = new StudentBll();
            _teacherBll = new TeacherBll();
        }

        public ActionResult Index()
        {
            return RedirectToAction("Student");
        }

        public ActionResult Student()
        {
            //If you're logged in, you can't access this view
            if (Session["studentID"] != null || Session["teacherID"] != null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        public ActionResult Teacher()
        {
            //If you're logged in, you can't access this view
            if (Session["studentID"] != null || Session["teacherID"] != null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        /// <summary>
        /// Checks if email is in use.
        /// </summary>
        /// <param name="email">Stores email.</param>
        public JsonResult VerifyEmail(string email)
        {
            using (new SchoolDbContext())
            {
                if (_studentBll.IsEmailInUse(email))
                {
                    return Json(false, JsonRequestBehavior.AllowGet);
                }

                if (_teacherBll.IsEmailInUse(email))
                {
                    return Json(false, JsonRequestBehavior.AllowGet);
                }
            }
            return Json(true, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Creates student profile.
        /// </summary>
        /// <param name="student">Stores student information.</param>
        /// <returns>To View redirection.</returns>
        [HttpPost]
        public ActionResult CreateStudent(Student student)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index", "Home");
            }
            _studentBll.AddStudent(student);
            Session["studentID"] = student.Id;
            return RedirectToAction("Index", "Home");
        }

        /// <summary>
        /// Creates teacher profile.
        /// </summary>
        /// <param name="teacher">Stores teacher information.</param>
        /// <returns>To View redirection.</returns>
        [HttpPost]
        public ActionResult CreateTeacher(Teacher teacher)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index", "Home");
            }
            _teacherBll.AddTeacher(teacher);
            Session["teacherID"] = teacher.Id;
            return RedirectToAction("Index", "Home");
        }
    }
}