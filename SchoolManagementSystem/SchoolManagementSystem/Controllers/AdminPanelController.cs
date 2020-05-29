using Business;
using System.Web.Mvc;

namespace SchoolManagementSystem.Controllers
{
    public class AdminPanelController : Controller
    {
        private readonly ITeacherBll _teacherBll;
        private readonly IStudentBll _studentBll;

        public AdminPanelController()
        {
            _teacherBll = new TeacherBll();
            _studentBll = new StudentBll();
        }

        // GET: AdminPanel
        public ActionResult Index()
        {
            return View("Home");
        }

        public ActionResult Teachers()
        {
            if(Session["adminId"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            return View(_teacherBll.GetAll());
        }

        public ActionResult Students()
        {
            if (Session["adminId"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            return View(_studentBll.GetAll());
        }

        /// <summary>
        /// Deactivates a teacher profile of the given ID and redirects to the same page
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult DeleteTeacher(int id)
        {
            if (Session["adminId"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            _teacherBll.DeleteTeacher(id);
            return RedirectToAction("Teachers");
        }

        /// <summary>
        /// Deactivates a student profile of the given ID and redirects to the same page
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult DeleteStudent(int id)
        {
            if (Session["adminId"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            _studentBll.DeleteStudent(id);
            return RedirectToAction("Students");
        }
    }
}