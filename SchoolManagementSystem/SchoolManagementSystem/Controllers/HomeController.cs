using Business;
using System.Web.Mvc;

namespace SchoolManagementSystem.Controllers
{    
    public class HomeController : Controller
    {
        private readonly StudentBll _studentBll = new StudentBll();
        private readonly TeacherBll _teacherBll = new TeacherBll();

        public ActionResult Index()
        {
            if (Session["studentID"] == null && Session["teacherID"] == null)
            {
                return RedirectToAction("Index", "Login");
            } 

            if (Session["studentID"] != null)
            {
                return View(_studentBll.GetPerson((int)Session["studentID"]));
            } 
            return View(_teacherBll.GetPerson((int)Session["teacherID"]));
        }
        public ActionResult ClassStudent()
        {
            //Can't access if you're not logged in
            if (Session["studentID"] == null && Session["teacherID"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            if (Session["studentID"] != null)
            {
                return View(_studentBll.GetStudentsFromClass((int)Session["studentID"]));
            }

            return RedirectToAction("Index", "Home");
        }
        public ActionResult ClassTeacher()
        {
            //Can't access if you're not logged in
            if (Session["studentID"] == null && Session["teacherID"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            if (Session["teacherID"] != null)
            {
                return View(_studentBll.GetStudentsFromClass((int)Session["teacherID"]));
            }

            return RedirectToAction("Index", "Home");
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

        public ActionResult Messages()
        {
            //Rewrite
            return RedirectToAction("Index", "Home");
        }
        public new ActionResult Profile()
        {
            //Rewrite
            return RedirectToAction("Index", "Home");
        }
    }
}