using Business;
using System.Web.Mvc;

namespace SchoolManagementSystem.Controllers
{    
    public class HomeController : Controller
    {
        private StudentBLL studentBLL = new StudentBLL();
        private TeacherBLL teacherBLL = new TeacherBLL();

        public ActionResult Index()
        {
            if (Session["studentID"] == null && Session["teacherID"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else if (Session["studentID"] != null)
            {
                return View(studentBLL.GetPerson((int)Session["studentID"]));
            }
            else 
            {
                return View(teacherBLL.GetPerson((int)Session["teacherID"]));
            }            
        }
        public ActionResult Class()
        {
            //Can't access if you're not logged in
            if (Session["studentID"] == null && Session["teacherID"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            return View(studentBLL.GetStudentsFromClass((int)Session["studentID"]));
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