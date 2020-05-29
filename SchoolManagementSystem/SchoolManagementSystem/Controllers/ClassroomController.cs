using Business;
using System.Web.Mvc;

namespace SchoolManagementSystem.Controllers
{
    public class ClassroomController : Controller
    {
        private readonly IStudentBll _studentBll;

        public ClassroomController()
        {
            _studentBll = new StudentBll();
        }

        public ActionResult Index()
        {
            if (Session["studentID"] != null)
            {
                return RedirectToAction("Classmates");
            }

            if (Session["teacherID"] != null)
            {
                return RedirectToAction("Classes");
            }

            return RedirectToAction("Index", "Login");
        }

        /// <summary>
        /// Will contain all the students that are for the same class as the logged in student.
        /// </summary>
        /// <returns>To student class View.</returns>
        public ActionResult Classmates()
        {
            if (Session["studentID"] == null && Session["teacherID"] == null)
            {
                return RedirectToAction("Index", "Login");
            }

            return View(_studentBll.GetStudentsFromClass((int)Session["studentID"]));
        }

        /// <summary>
        /// Allows the user the see every student from the given class information.
        /// </summary>
        /// <param name="classNumber"></param>
        /// <param name="classLetter"></param>
        /// <returns>To teacher classes View.</returns>
        public ActionResult Classes(int classNumber = 7, string classLetter = "A")
        {
            if (Session["studentID"] == null && Session["teacherID"] == null)
            {
                return RedirectToAction("Index", "Login");
            }

            return View(_studentBll.GetStudentsFromClass(classNumber, classLetter));
        }

        /// <summary>
        /// Contains more detailed information about the student.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>To student details View.</returns>
        public ActionResult StudentDetails(int id = 1)
        {
            //Can't access if you're not logged in
            if (Session["studentID"] == null && Session["teacherID"] == null)
            {
                return RedirectToAction("Index", "Login");
            }

            return View(_studentBll.GetStudent(id));
        }
    }
}