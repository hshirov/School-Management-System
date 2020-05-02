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
            else if (Session["studentID"] != null)
            {
                return View(_studentBll.GetPerson((int)Session["studentID"]));
            }
            else 
            {
                return View(_teacherBll.GetPerson((int)Session["teacherID"]));
            }            
        }
        public ActionResult Class()
        {
            //Rewrite
            return RedirectToAction("Index", "Home");
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