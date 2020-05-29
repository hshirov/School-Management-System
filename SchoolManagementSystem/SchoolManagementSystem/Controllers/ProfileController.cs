using Business;
using Data.Models;
using System.Web.Mvc;

namespace SchoolManagementSystem.Controllers
{
    public class ProfileController : Controller
    {
        private readonly IStudentBll _studentBll;
        private readonly ITeacherBll _teacherBll;

        public ProfileController()
        {
            _studentBll = new StudentBll();
            _teacherBll = new TeacherBll();
        }

        /// <summary>
        /// Checks session id for student.
        /// </summary>
        /// <returns>To student View or back up to check session.</returns>
        public ActionResult Student()
        {
            if (Session["studentID"] == null && Session["teacherId"] == null)
            {
                return RedirectToAction("Index", "Login");
            }

            if (Session["teacherId"] != null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View(_studentBll.GetStudent((int)Session["studentId"]));
        }

        /// <summary>
        /// Checks session id for teacher.
        /// </summary>
        /// <returns>To teacher View or back up to check session.</returns>
        public ActionResult Teacher()
        {
            if (Session["studentID"] == null && Session["teacherId"] == null)
            {
                return RedirectToAction("Index", "Login");
            }

            if (Session["studentID"] != null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View(_teacherBll.GetTeacher((int)Session["teacherId"]));
        }

        /// <summary>
        /// Repeats student password validation due to invalid password.
        /// Repeats DeleteStudent.
        /// </summary>
        /// <returns>This View.</returns>
        public ActionResult DeactivateStudent()
        {
            return View();
        }

        /// <summary>
        /// Repeats teacher password validation due to invalid password.
        /// Repeats DeleteTeacher.
        /// </summary>
        /// <returns>This View.</returns>
        public ActionResult DeactivateTeacher()
        {
            return View();
        }

        /// <summary>
        /// Updates student profile information.
        /// </summary>
        /// <param name="student">Stores student information.</param>
        /// <returns>To student View.</returns>
        [HttpPost]
        public ActionResult UpdateStudent(Student student)
        {
            student.Id = (int)Session["studentId"];
            _studentBll.UpdateStudent(student);
            ViewData["Message"] = "Success";
            return View("Student");
        }

        /// <summary>
        /// Updates teacher profile information.
        /// </summary>
        /// <param name="teacher">Stores teacher information.</param>
        /// <returns>To teacher View.</returns>
        [HttpPost]
        public ActionResult UpdateTeacher(Teacher teacher)
        {
            teacher.Id = (int)Session["teacherId"];
            _teacherBll.UpdateTeacher(teacher);
            ViewData["Message"] = "Success";
            return View("Teacher");
        }

        /// <summary>
        /// Deletes student profile
        /// </summary>
        /// <param name="student">Stores student information.</param>
        /// <returns>To LogOut action or repeats action if password is not valid</returns>
        [HttpPost]
        public ActionResult DeleteStudent(Student student)
        {
            student.Id = (int)Session["studentId"];
            if (!_studentBll.IsPasswordValid(student))
            {
                ViewData["Message"] = "Error";
                return View("DeactivateStudent");
            }

            _studentBll.DeleteStudent(student.Id);
                return RedirectToAction("LogOut", "Login");
        }

        /// <summary>
        /// Deletes teacher profile
        /// </summary>
        /// <param name="teacher">Stores teacher information.</param>
        /// <returns>To LogOut action or repeats action if password is not valid</returns>
        [HttpPost]
        public ActionResult DeleteTeacher(Teacher teacher)
        {
            teacher.Id = (int)Session["teacherId"];
            if (!_teacherBll.IsPasswordValid(teacher))
            {
                ViewData["Message"] = "Error";
                return View("DeactivateTeacher");
            }

            _teacherBll.DeleteTeacher(teacher.Id);
                return RedirectToAction("LogOut", "Login");
        }
    }
}