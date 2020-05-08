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
            if(Session["studentID"] != null)
            {
                return View(_studentBll.GetPerson((int)Session["studentID"]));
            }
            else if(Session["teacherID"] != null)
            {
                return View(_teacherBll.GetPerson((int)Session["teacherID"]));
            }

            return RedirectToAction("Index", "Login");
        }

        public ActionResult Messages()
        {
            //Rewrite
            return RedirectToAction("Index", "Home");
        }
    }
}