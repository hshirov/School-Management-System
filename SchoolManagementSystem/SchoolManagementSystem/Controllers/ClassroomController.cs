using Business;
using System.Web.Mvc;

namespace SchoolManagementSystem.Controllers
{
    public class ClassroomController : Controller
    {
        private readonly StudentBll _studentBll;

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
            else if (Session["teacherID"] != null)
            {
                return RedirectToAction("Classes");
            }

            return RedirectToAction("Index", "Login");
        }

        public ActionResult Classmates()
        {
            if (Session["studentID"] == null && Session["teacherID"] == null)
            {
                return RedirectToAction("Index", "Login");
            }

            return View(_studentBll.GetStudentsFromClass((int)Session["studentID"]));
        }

        public ActionResult Classes(int classNumber = 7, string classLetter = "A")
        {
            if (Session["studentID"] == null && Session["teacherID"] == null)
            {
                return RedirectToAction("Index", "Login");
            }

            return View(_studentBll.GetStudentsFromClass(classNumber, classLetter));
        }

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