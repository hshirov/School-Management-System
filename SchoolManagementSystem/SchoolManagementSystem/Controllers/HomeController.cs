using Business;
using System.Web.Mvc;

namespace SchoolManagementSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly IStudentBll _studentBll;
        private readonly ITeacherBll _teacherBll;

        public HomeController()
        {
            _studentBll = new StudentBll();
            _teacherBll = new TeacherBll();
        }

        /// <summary>
        /// Checks session 
        /// </summary>
        /// <returns>To View session.</returns>
        public ActionResult Index()
        {
            if (Session["studentID"] != null)
            {
                return View(_studentBll.GetPerson((int)Session["studentID"]));
            }

            if (Session["teacherID"] != null)
            {
                return View(_teacherBll.GetPerson((int)Session["teacherID"]));
            }

            return RedirectToAction("Index", "Login");
        }
    }
}